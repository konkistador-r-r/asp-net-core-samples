#pragma checksum "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39d01ac41d93e1834bd4871e9b9ca62fff20a2a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorTagHelpersNetCore.Pages.Pages_ModelBindingSamples), @"mvc.1.0.razor-page", @"/Pages/ModelBindingSamples.cshtml")]
namespace RazorTagHelpersNetCore.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{myRouteParamName?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39d01ac41d93e1834bd4871e9b9ca62fff20a2a5", @"/Pages/ModelBindingSamples.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799d2f09735d17fcf19fe2acc1f827c27db7ea38", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ModelBindingSamples : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
  
    ViewData["Title"] = "ModelBindingSamples";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 8 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
Write(ViewData["errorMessages"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<h3>");
#nullable restore
#line 10 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
Write(ViewData["confirmation"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a55534", async() => {
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label for=\"Name\" class=\"col-sm-2 control-label\">Name</label>\r\n        <div class=\"col-sm-10\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a55952", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 16 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
    </div>
    <div class=""form-group"">
        <label for=""Email"" class=""col-sm-2 control-label"">Email</label>
        <div class=""col-sm-10"">
            <input type=""text"" class=""form-control"" name=""e-m-a-i-l"">
        </div>
    </div>
    <div class=""form-group"">
        <label for=""Phone"" class=""col-sm-2 control-label"">Phone</label>
        <div class=""col-sm-10"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a58208", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 28 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ContactInfoForFields.Phone);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"Address\" class=\"col-sm-2 control-label\">Address</label>\r\n        <div class=\"col-sm-10\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a510252", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 34 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ContactInfoForFields.Address);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
    </div>
    <div class=""form-group"">
        <label for=""MovieCategoryIds"" class=""col-sm-12 control-label"">Which types of film do you like? (Tick all that apply)</label>
        <div class=""col-sm-10"">
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""1""> Factual<br />
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""2""> Horror<br />
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""3""> Historical<br />
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""4""> SciFi<br />
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""5""> Comedy<br />
            <input type=""checkbox"" name=""MovieCategoryIds"" value=""6""> Fantasy<br />
        </div>
    </div>
    <div class=""form-group"">
        <label class=""col-sm-2 control-label"">Add multiple employess at once</label>
        <table class=""table table-striped"">
            <tr>
                <th>FullName</th>
                <th>OfficePosition</th>
     ");
                WriteLiteral("       </tr>\r\n");
#nullable restore
#line 55 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
             for (int i = 0; i < 3; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        <!-- attention: use asp-for instead of name!  -->\r\n                        <!-- do not generate Id if do not whant entity with empty props -->\r\n");
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a513796", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 62 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NewEmployees[i].FullName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" <!-- The index can be any value that uniquely identifies a data item.  -->\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a515709", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 65 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NewEmployees[i].OfficePosition);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" <!-- [1].OfficePosition: [index].propertyname or parametername[index].propertyname -->\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 68 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </table>
    </div>
    <div class=""form-group"">
        <label class=""col-sm-2 control-label"">Edit multiple employess at once</label>
        <table class=""table table-striped"">
            <tr>
                <th>ID</th>
                <th>FullName</th>
                <th>OfficePosition</th>
            </tr>
");
#nullable restore
#line 79 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
             foreach (var employee in Model.EditEmployees)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <tr>
                    <td>
                        <!-- The model binders uses the Contacts.Index field value to group other values. -->
                        <!-- attention: use name instead of asp-for! -->
                        <input type=""hidden"" name=""EditEmployees.Index""");
                BeginWriteAttribute("value", " value=\"", 3869, "\"", 3897, 1);
#nullable restore
#line 85 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 3877, employee.EmployeeId, 3877, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 3947, "\"", 4000, 3);
                WriteAttributeValue("", 3954, "EditEmployees[", 3954, 14, true);
#nullable restore
#line 86 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 3968, employee.EmployeeId, 3968, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3988, "].EmployeeId", 3988, 12, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4001, "\"", 4029, 1);
#nullable restore
#line 86 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 4009, employee.EmployeeId, 4009, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        ID: ");
#nullable restore
#line 87 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
                       Write(employee.EmployeeId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <input type=\"text\"");
                BeginWriteAttribute("name", " name=\"", 4180, "\"", 4231, 3);
                WriteAttributeValue("", 4187, "EditEmployees[", 4187, 14, true);
#nullable restore
#line 90 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 4201, employee.EmployeeId, 4201, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4221, "].FullName", 4221, 10, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4232, "\"", 4258, 1);
#nullable restore
#line 90 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 4240, employee.FullName, 4240, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /> <!-- The index can be any value that uniquely identifies a data item.  -->\r\n                    </td>\r\n                    <td>\r\n                        <input type=\"text\"");
                BeginWriteAttribute("name", " name=\"", 4434, "\"", 4491, 3);
                WriteAttributeValue("", 4441, "EditEmployees[", 4441, 14, true);
#nullable restore
#line 93 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 4455, employee.EmployeeId, 4455, 20, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4475, "].OfficePosition", 4475, 16, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4492, "\"", 4524, 1);
#nullable restore
#line 93 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
WriteAttributeValue("", 4500, employee.OfficePosition, 4500, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /> <!-- [1].OfficePosition: [index].propertyname or parametername[index].propertyname -->\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 96 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n    <h3>Order Items</h3>\r\n    <div class=\"form-group\">\r\n        <label for=\"Order.Customer\" class=\"col-sm-2 control-label\">Customer</label>\r\n        <div class=\"col-sm-10\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a523449", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 104 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Order.Customer);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"Order.OrderItems[0].Item\" class=\"col-sm-2 control-label\">Item</label>\r\n        <div class=\"col-sm-10\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a525497", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 110 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Order.OrderItems[0].Item);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"Order.OrderItems[0].Price\" class=\"col-sm-2 control-label\">Price</label>\r\n        <div class=\"col-sm-10\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "39d01ac41d93e1834bd4871e9b9ca62fff20a2a527557", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 116 "D:\Projects\GitHubFree\asp-net-core-samples\Tutorialsteacher\RazorTagHelpersNetCore\Pages\ModelBindingSamples.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Order.OrderItems[0].Price);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-sm-offset-2 col-sm-10\">\r\n            <button type=\"submit\" class=\"btn btn-default\">Register</button>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorTagHelpersNetCore.Pages.ModelBindingSamplesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.ModelBindingSamplesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorTagHelpersNetCore.Pages.ModelBindingSamplesModel>)PageContext?.ViewData;
        public RazorTagHelpersNetCore.Pages.ModelBindingSamplesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
