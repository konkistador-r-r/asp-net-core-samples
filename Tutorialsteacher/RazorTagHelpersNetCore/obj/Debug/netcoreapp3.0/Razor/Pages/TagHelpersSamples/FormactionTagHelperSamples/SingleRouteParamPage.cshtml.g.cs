#pragma checksum "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\TagHelpersSamples\FormactionTagHelperSamples\SingleRouteParamPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91ba9c2d7e4a8c56e416325c9314822da340a7fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples.Pages_TagHelpersSamples_FormactionTagHelperSamples_SingleRouteParamPage), @"mvc.1.0.razor-page", @"/Pages/TagHelpersSamples/FormactionTagHelperSamples/SingleRouteParamPage.cshtml")]
namespace RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{singleParam?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91ba9c2d7e4a8c56e416325c9314822da340a7fe", @"/Pages/TagHelpersSamples/FormactionTagHelperSamples/SingleRouteParamPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799d2f09735d17fcf19fe2acc1f827c27db7ea38", @"/Pages/_ViewImports.cshtml")]
    public class Pages_TagHelpersSamples_FormactionTagHelperSamples_SingleRouteParamPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Passed param: ");
#nullable restore
#line 6 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\TagHelpersSamples\FormactionTagHelperSamples\SingleRouteParamPage.cshtml"
             Write(Model.SingleParam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<h1>Passed data: ");
#nullable restore
#line 8 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\TagHelpersSamples\FormactionTagHelperSamples\SingleRouteParamPage.cshtml"
            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples.SingleRouteParamPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples.SingleRouteParamPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples.SingleRouteParamPageModel>)PageContext?.ViewData;
        public RazorTagHelpersNetCore.Pages.TagHelpersSamples.FormactionTagHelperSamples.SingleRouteParamPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591