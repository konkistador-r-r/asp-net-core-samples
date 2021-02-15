using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace LocalizationCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly List<ViewModels.Index.Language> _languages;

        [BindProperty] public string DdlLanguagesSelectedValue { get; set; }
        public List<SelectListItem> DdlLanguagesDataSource { get; set; }
        public string LblCurrentLanguage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _languages = GetLanguages();

            SetPageModelData();
        }

        public void OnGet()
        {
            RefreshPageModel();
        }

        public void OnPost() {
            RefreshPageModel();
        }

        private List<ViewModels.Index.Language> GetLanguages() { 
            return new List<ViewModels.Index.Language>()
            {
                new ViewModels.Index.Language{ Code="en-US", Name = "English" },
                new ViewModels.Index.Language{ Code="de", Name = "German" },
                new ViewModels.Index.Language{ Code="it", Name = "Italian" },
                new ViewModels.Index.Language{ Code="fr", Name = "French" }
            };
        }
        private void RefreshPageModel() {
            SetLanguage(DdlLanguagesSelectedValue);
            DdlLanguagesDataSource = _languages.Select(l => new SelectListItem(l.Name, l.Code)).ToList();

            IRequestCultureFeature requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            RequestCulture requestCulture = requestCultureFeature.RequestCulture;
            LblCurrentLanguage = requestCulture.Culture.Name;
        }
        private void SetPageModelData() {
            DdlLanguagesSelectedValue = _languages.First().Code;
        }
        private void SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }
    }
}
