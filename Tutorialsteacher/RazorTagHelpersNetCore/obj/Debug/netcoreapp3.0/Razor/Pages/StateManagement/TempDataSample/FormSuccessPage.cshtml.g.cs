#pragma checksum "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\StateManagement\TempDataSample\FormSuccessPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed7b4f1cdf8aeea8f04070a536af7dbdfcc73f45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample.Pages_StateManagement_TempDataSample_FormSuccessPage), @"mvc.1.0.razor-page", @"/Pages/StateManagement/TempDataSample/FormSuccessPage.cshtml")]
namespace RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\_ViewImports.cshtml"
using RazorTagHelpersNetCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed7b4f1cdf8aeea8f04070a536af7dbdfcc73f45", @"/Pages/StateManagement/TempDataSample/FormSuccessPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799d2f09735d17fcf19fe2acc1f827c27db7ea38", @"/Pages/_ViewImports.cshtml")]
    public class Pages_StateManagement_TempDataSample_FormSuccessPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\StateManagement\TempDataSample\FormSuccessPage.cshtml"
  
    ViewData["Title"] = "FormSuccessPage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>FormSuccessPage</h1>\r\n\r\n");
            WriteLiteral("\r\n<!-- Can access value second time but not on page refresh -->\r\n<h4>FormResult: ");
#nullable restore
#line 12 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\StateManagement\TempDataSample\FormSuccessPage.cshtml"
           Write(Model.FormResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n<h4>EmailAddress: ");
#nullable restore
#line 14 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\StateManagement\TempDataSample\FormSuccessPage.cshtml"
             Write(Model.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample.FormSuccessPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample.FormSuccessPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample.FormSuccessPageModel>)PageContext?.ViewData;
        public RazorTagHelpersNetCore.Pages.StateManagement.TempDataSample.FormSuccessPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591