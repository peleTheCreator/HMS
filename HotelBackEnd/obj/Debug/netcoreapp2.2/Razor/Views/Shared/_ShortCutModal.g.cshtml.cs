#pragma checksum "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\Shared\_ShortCutModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "162e686a5c6d4a29e60b8d61310dc6274b03ee5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ShortCutModal), @"mvc.1.0.view", @"/Views/Shared/_ShortCutModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ShortCutModal.cshtml", typeof(AspNetCore.Views_Shared__ShortCutModal))]
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
#line 1 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd;

#line default
#line hidden
#line 2 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd.Models;

#line default
#line hidden
#line 3 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd.Entities;

#line default
#line hidden
#line 4 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd.Services;

#line default
#line hidden
#line 5 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd.ViewModel;

#line default
#line hidden
#line 6 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\_ViewImports.cshtml"
using HotelBackEnd.Controllers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"162e686a5c6d4a29e60b8d61310dc6274b03ee5a", @"/Views/Shared/_ShortCutModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6158612a6d681ad8dc29978efd4454eac227b088", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ShortCutModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 455, true);
            WriteLiteral(@"<!-- modal shortcut -->
<div class=""modal fade modal-backdrop-transparent"" id=""modal-shortcut"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-shortcut"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-top modal-transparent"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-body"">
                <ul class=""app-list w-auto h-auto p-0 text-left"">
                    <li>
                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 455, "\"", 493, 1);
#line 8 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\Shared\_ShortCutModal.cshtml"
WriteAttributeValue("", 462, Url.Action("Index", "Booking"), 462, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(494, 694, true);
            WriteLiteral(@" class=""app-list-item text-white border-0 m-0"">
                            <div class=""icon-stack"">
                                <i class=""base base-7 icon-stack-3x opacity-100 color-primary-500 ""></i> 
                                <i class=""base base-7 icon-stack-2x opacity-100 color-primary-300 ""></i> 
                                <i class=""fal fa-home icon-stack-1x opacity-100 color-white""></i>
                            </div>
                            <span class=""app-list-name"">
                                Home
                            </span>
                        </a>
                    </li>
                    <li>
                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1188, "\"", 1230, 1);
#line 20 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\Shared\_ShortCutModal.cshtml"
WriteAttributeValue("", 1195, Url.Action("InboxGeneral", "Page"), 1195, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1231, 713, true);
            WriteLiteral(@" class=""app-list-item text-white border-0 m-0"">
                            <div class=""icon-stack"">
                                <i class=""base base-7 icon-stack-3x opacity-100 color-success-500 ""></i> 
                                <i class=""base base-7 icon-stack-2x opacity-100 color-success-300 ""></i> 
                                <i class=""ni ni-envelope icon-stack-1x text-white""></i>   
                            </div>
                            <span class=""app-list-name"">
                                Inbox
                            </span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
