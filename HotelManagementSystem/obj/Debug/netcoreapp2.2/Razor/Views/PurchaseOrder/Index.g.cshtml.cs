#pragma checksum "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bab2e7eb6883f6f492f39c19dda07bc0deee7914"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrder_Index), @"mvc.1.0.view", @"/Views/PurchaseOrder/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PurchaseOrder/Index.cshtml", typeof(AspNetCore.Views_PurchaseOrder_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab2e7eb6883f6f492f39c19dda07bc0deee7914", @"/Views/PurchaseOrder/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bdbaa8e4c8d6ad47c0cf58be6ee3b36d4d68532", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrder_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PurchaseOrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#DeleteModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
  
    ViewData["Title"] = "PurchaseOrder";
    Layout = "~/Views/Shared/_LayoutInventory.cshtml";

#line default
#line hidden
            BeginContext(151, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(158, 17, false);
#line 8 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(175, 18, true);
            WriteLiteral("</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(193, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bab2e7eb6883f6f492f39c19dda07bc0deee79149169", async() => {
                BeginContext(216, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(230, 70, true);
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\" id=\"grid\">\r\n    <thead>\r\n        <tr>\r\n");
            EndContext();
            BeginContext(394, 34, true);
            WriteLiteral("            <th>\r\n                ");
            EndContext();
            BeginContext(429, 42, false);
#line 21 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Vendor));

#line default
#line hidden
            EndContext();
            BeginContext(471, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(527, 43, false);
#line 24 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Product));

#line default
#line hidden
            EndContext();
            BeginContext(570, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(626, 53, false);
#line 27 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PurchaseOrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(679, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(735, 44, false);
#line 30 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(779, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(835, 45, false);
#line 33 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CostOfOne));

#line default
#line hidden
            EndContext();
            BeginContext(880, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(936, 45, false);
#line 36 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(981, 124, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Action\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 44 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1154, 18, true);
            WriteLiteral("            <tr>\r\n");
            EndContext();
            BeginContext(1285, 42, true);
            WriteLiteral("                <td>\r\n                    ");
            EndContext();
            BeginContext(1328, 41, false);
#line 51 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Vendor));

#line default
#line hidden
            EndContext();
            BeginContext(1369, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1437, 42, false);
#line 54 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Product));

#line default
#line hidden
            EndContext();
            BeginContext(1479, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1547, 52, false);
#line 57 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PurchaseOrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(1599, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1667, 43, false);
#line 60 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(1710, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1778, 44, false);
#line 63 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CostOfOne));

#line default
#line hidden
            EndContext();
            BeginContext(1822, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1890, 44, false);
#line 66 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(1934, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2001, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bab2e7eb6883f6f492f39c19dda07bc0deee791417051", async() => {
                BeginContext(2083, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 69 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
                                           WriteLiteral(item.PurchaseOrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2091, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
            BeginContext(2338, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(2358, 179, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bab2e7eb6883f6f492f39c19dda07bc0deee791419650", async() => {
                BeginContext(2527, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
#line 72 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
                                                        Write(item.PurchaseOrderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-roomtype-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 72 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
                                                                                                   Write(item.Product);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-roomtype-name", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2537, 46, true);
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 76 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelManagementSystem\HotelManagementSystem\Views\PurchaseOrder\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2594, 565, true);
            WriteLiteral(@"    </tbody>
</table>

<div class=""modal fade"" id=""DeleteModal"" role=""dialog"">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Delete PurchaseOrder?</h4>
            </div>
            <div class=""modal-body"">
                <p id=""DeleteConfirmation""></p>
            </div>
            <div class=""modal-footer"">
                ");
            EndContext();
            BeginContext(3159, 315, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bab2e7eb6883f6f492f39c19dda07bc0deee791423395", async() => {
                BeginContext(3199, 268, true);
                WriteLiteral(@"
                    <input type=""hidden"" name=""id"" value="""" />
                    <input type=""submit"" value=""Delete"" class=""btn btn-success"" />
                    <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Close</button>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3474, 83, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div> <!-- DeleteModal -->\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3574, 661, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#grid').DataTable();
        });

        $('#DeleteModal').on('show.bs.modal', function (e) {
            //get data-id attribute of the clicked element
            var roomtypeID = $(e.relatedTarget).data('roomtype-id');
            var room_type_name = $(e.relatedTarget).data('roomtype-name');
            var deleteMessage = ""Are you sure you want to delete Purchaseorder for this product: "" + room_type_name + """";
            $('#DeleteConfirmation').html(deleteMessage);
            $(e.currentTarget).find('input[name=""id""]').val(roomtypeID);
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(4238, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PurchaseOrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
