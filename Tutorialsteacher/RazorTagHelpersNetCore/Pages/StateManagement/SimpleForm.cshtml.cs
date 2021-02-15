using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace RazorTagHelpersNetCore.Pages.StateManagement
{
    public class SimpleFormModel : PageModel
    {
        private Guid _contactId = new Guid("FC175302-0AB4-45A2-83A7-BBEEB6C4C8C7");

        // 1. State Management by: Hidden Form Fields
        // 2. State Management by: Query Strings
        [BindProperty(SupportsGet = true)]
        public Guid ContactId { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }

        private readonly IMemoryCache _cache;
        public SimpleFormModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnGet()
        {
            if (Request.Query.ContainsKey("ContactId"))
            {
                // set pivate field
                _contactId = ContactId;
            }
            else {
                ContactId = _contactId;
            }

            SetSessionValues();
            CacheFileContent();
        }

        // PageHandlers do not work like OnGetWithQueryStringParams only Post
        public IActionResult OnPostWithQueryStringParams()
        {
            // 2. State Management by: Query Strings
            // 3. State Management by: Route Data
            // redirect with route parameter value
            return RedirectToPage("/ModelBindingSamples", new { myRouteParamName = "value1", name2 = "value2" });
            //return RedirectToPage("/ModelBindingSamples");
            // The resulting URL shows how name2 and its associated value2 is appended as a query string name/value pair, 
            // while the route value that's catered for in the template is passed as a segment: http://localhost:xxx/ModelBindingSamples/value1?name2=value2
        }

        public void OnPost()
        {
            GetSessionValues();
            DeleteSessionValues();

            string fileContentString = _cache.Get<string>("ExampleFileContent"); // after file changed value is null

            // 1.Validation based on Data attributes
            if (!ModelState.IsValid)
            {
                return;
            }

            // 2.Custom validation
            if (Request.Query.ContainsKey("ContactId"))
            {
                // set pivate field
                _contactId = Guid.Parse(Request.Query["ContactId"]);
            }
            bool myCustomValidation = ContactId == _contactId;
            if (!myCustomValidation)
            {
                // If PageModel property is not decorated with BindProperty attribute, 
                // and used input instead of Input Tag Helper with asp-for=”propertyName” attribute 
                // than propertyValue will not be transferred back to client after form postback.
                return;
            }

            // 3.Process data
        }

        #region 4. State Management by: Cookies
        private void SetCookie(string key, string value, CookieOptions options = null) {
            Response.Cookies.Append(key, value, options);
        }
        private string GetCookie(string key)
        {
            var cookieValue = Request.Cookies[key]; //return null if not exists
            return cookieValue;
        }
        private void DeleteCookie(string key, CookieOptions options = null) {
            Response.Cookies.Delete(key, options);
        }
        private void SampleSetCookieExpiryTime() {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // 	The expiry date
            };
            SetCookie("MyCookieKey", "value1", cookieOptions);
        }
        private void SampleSetCookieOtherOprions()
        {
            // https://www.learnrazorpages.com/razor-pages/cookies
            // https://stackoverflow.com/questions/1062963/how-do-browser-cookie-domains-work
            // means do not allow other domains=web apps to read your cookie
            // llok like use less
            var cookieOptions = new CookieOptions
            {
                // The domain(s) that the cookie is accessible to. 
                // If it is not specified, the cookie is only sent to the domain of the current document.
                // If provided, all sub-domains are also included.
                Domain = "mydomain",
                //  If set to true, the cookie is only available to code executing on the server, not from javascript
                HttpOnly = true,
                // If not specified, the cookie is available to all pages in the domain(s)
                // available only at SimpleForm and it Subdirectories.
                Path = "/SimpleForm",
                // prevention of CSRF or cookie hijacking attacks. Lax (default), None, Strict
                SameSite = SameSiteMode.Strict,
                // Specifies whether the cookie should only be sent with secure (HTTPS) requests. 
                // The default is false, which means that the cookie will be sent on all requests, regardless of protocol.
                Secure = true
            };
            SetCookie("MyCookieKey", "value1", cookieOptions);
        }

        // Cookies are limited to around 4Kb in size each/per domain (depending on the browser) 
        // and are consequently not the place for storing large amounts of data. 
        // The Web Storage API is the recommended alternative for this purpose.
        // Web Storage concepts and usage
        // https://developer.mozilla.org/en-US/docs/Web/API/Web_Storage_API
        // See samples in this page
        #endregion

        #region 6. State Management by: Session
        private void SetSessionValues() {
            HttpContext.Session.SetString("Test String", "1");
            HttpContext.Session.SetInt32("Test Int", 1);
            //HttpContext.Session.Set("Test Byte Array", BitConverter.GetBytes(true)); // boolean as byte array
            HttpContext.Session.SetBoolean("Test Bool", true);
        }
        private void GetSessionValues() {
            ViewData["Test String"] = HttpContext.Session.GetString("Test String"); // return null if no value has been set for the referenced key
            ViewData["Test Int"] = HttpContext.Session.GetInt32("Test Int");
            //var val = HttpContext.Session.Get("Test Byte Array");
            //if (HttpContext.Session.TryGetValue("Test Byte Array", out byte[] result))
            //{
            //    ViewData["Test Byte Array"] = BitConverter.ToBoolean(result, 0);
            //}
            ViewData["Test Byte Array"] = HttpContext.Session.GetBoolean("Test Bool");
        }
        private void DeleteSessionValues() {
            HttpContext.Session.Remove("Test Byte Array");
            HttpContext.Session.Clear();
        }
        #endregion

        #region 7. State Management by: In-Memory Cache
        private void SetCacheValues() {
            using (var cacheEntry1 = _cache.CreateEntry("myKey1"))
            {
                // set properties
                cacheEntry1.SetValue(12345);
            } // Dispose called at end of block, committing item to the cache

            // or
            
            var cacheEntry2 = _cache.CreateEntry("myKey2");
            // set properties
            cacheEntry2.SetValue(12345);
            cacheEntry2.Dispose(); //adds item to cache

            // or
            // will add an entry if one doesn't exist for the specified key:
            int intVal = _cache.GetOrCreate("myKey3", entry => {
                return 12345; // value which will be added to the cache with the specified key.
            });

            // or
            // The simplest way to add an entry to the cache
            _cache.Set<DateTime>("Time", DateTime.Now);

        }
        private void GetCacheValues() {
            var myKey = _cache.Get("myKey1");

            // or
             
            var time = _cache.Get<DateTime>("Time");

            // or

            DateTime dt;
            if (_cache.TryGetValue("Time", out dt))
            {
                // the cache entry has been retrieved
            }

            // or
            // will add an entry if one doesn't exist for the specified key:
            int intVal = _cache.GetOrCreate("myKey3", entry => {
                return 12345; // value which will be added to the cache with the specified key.
            });
        }
        private void DeleteCacheValues() {
            _cache.Remove("myKey1");
        }
        private void SetCacheExpiryTime() {
            // The AbsoluteExpiration property enables you to set the actual time that an item should expire
            using (var cacheItem = _cache.CreateEntry("MyKey1"))
            {
                cacheItem.SetValue(12345);
                // sets the entry to expire just before midnight on News Year's Eve, 2018 regardless when it was added
                cacheItem.AbsoluteExpiration = new DateTimeOffset(new DateTime(2018, 12, 31, 23, 59, 59)); // The expiry date
            }

            // AbsoluteExpirationRelativeToNow - specify a duration, such as 20 minutes from the time that the item is added to the cache.
            using (var cacheItem = _cache.CreateEntry("MyKey2"))
            {
                cacheItem.SetValue(12345);
                // sets the entry to expire just before midnight on News Year's Eve, 2018 regardless when it was added
                cacheItem.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20); // from now
            }

            // The SlidingExpiration property provides a means to expire infrequently accessed items after a specified period of inactivity
            using (var cacheItem = _cache.CreateEntry("MyKey3"))
            {
                cacheItem.SetValue(12345);
                // sets the entry to expire just before midnight on News Year's Eve, 2018 regardless when it was added
                cacheItem.SlidingExpiration = TimeSpan.FromMinutes(20); // from now
            }

            // You can also set these options via extension methods on an instance of the MemoryCacheEntryOptions class
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20));
            _cache.Set("Time", DateTime.Now, options);
        }
        private void ManageCacheWithDependencies() {
            // Items can also be expired from the cache as a result of a dependency
            var cancellationTokenSource = new CancellationTokenSource();
            var changeToken = new CancellationChangeToken(cancellationTokenSource.Token); // CompositeChangeToken
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20)).AddExpirationToken(changeToken);
            _cache.Set("MyKey5", "Value", options);

            //cancellationTokenSource.Cancel();
            //changeToken.HasChanged
        }
        private void CacheFileContent() {
            // Looks from the project root - D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\example.txt
            var filePath = @"Pages\StateManagement\example.txt"; 
            var fileContent = System.IO.File.ReadAllText(filePath);

            var fileInfo = new System.IO.FileInfo(filePath);
            var fileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(fileInfo.DirectoryName);
            // Calling Dispose stops the token from listening for further changes and releases the token's resources.
            var changeToken = fileProvider.Watch(fileInfo.Name);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20)).AddExpirationToken(changeToken);
            _cache.Set("ExampleFileContent", fileContent, options);

            string fileContentString = _cache.Get<string>("ExampleFileContent");
        }
        #endregion

        // interesting sample
        public static byte[] ComputeHash(string filePath)
        {
            var runCount = 1;

            while (runCount < 4)
            {
                try
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        using (var fs = System.IO.File.OpenRead(filePath))
                        {
                            return System.Security.Cryptography.SHA1
                                .Create().ComputeHash(fs);
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (IOException ex)
                {
                    if (runCount == 3 || ex.HResult != -2147024864)
                    {
                        throw;
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
                        runCount++;
                    }
                }
            }

            return new byte[20];
        }
    }
}