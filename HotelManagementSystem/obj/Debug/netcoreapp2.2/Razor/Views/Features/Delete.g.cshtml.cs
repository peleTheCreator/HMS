#pragma checksum "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea6d81a4f7afead78e1781a8c3fac5ad43a379bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Features_Delete), @"mvc.1.0.view", @"/Views/Features/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Features/Delete.cshtml", typeof(AspNetCore.Views_Features_Delete))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem;

#line default
#line hidden
#line 2 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.ViewModel;

#line default
#line hidden
#line 3 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.ViewModel.Inventory;

#line default
#line hidden
#line 4 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.ViewModel.AccountViewModel;

#line default
#line hidden
#line 5 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.ViewModel.Blog;

#line default
#line hidden
#line 6 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Entities;

#line default
#line hidden
#line 7 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Entities.Blog;

#line default
#line hidden
#line 9 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 10 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Services;

#line default
#line hidden
#line 11 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Entities.InventotyEntities;

#line default
#line hidden
#line 12 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Controllers;

#line default
#line hidden
#line 13 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\_ViewImports.cshtml"
using HotelManagementSystem.Services.BlogServices;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6d81a4f7afead78e1781a8c3fac5ad43a379bf", @"/Views/Features/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bdbaa8e4c8d6ad47c0cf58be6ee3b36d4d68532", @"/Views/_ViewImports.cshtml")]
    public class Views_Features_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Feature>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(58, 164, true);
            WriteLiteral("<h2>Delete</h2>\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Feature</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(223, 40, false);
#line 12 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(263, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(307, 36, false);
#line 15 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(343, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(387, 40, false);
#line 18 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Icon));

#line default
#line hidden
            EndContext();
            BeginContext(427, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(471, 36, false);
#line 21 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Icon));

#line default
#line hidden
            EndContext();
            BeginContext(507, 34, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            EndContext();
            BeginContext(541, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea6d81a4f7afead78e1781a8c3fac5ad43a379bf8896", async() => {
                BeginContext(567, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(577, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ea6d81a4f7afead78e1781a8c3fac5ad43a379bf9286", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 26 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\Features\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(613, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(697, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea6d81a4f7afead78e1781a8c3fac5ad43a379bf11234", async() => {
                    BeginContext(719, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(735, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(748, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Feature> Html { get; private set; }
    }
}
#pragma warning restore 1591
