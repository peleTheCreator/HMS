#pragma checksum "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\Shared\_PageFooter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12d9206d706b19a66510a7a1695cb1323554ac23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PageFooter), @"mvc.1.0.view", @"/Views/Shared/_PageFooter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_PageFooter.cshtml", typeof(AspNetCore.Views_Shared__PageFooter))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12d9206d706b19a66510a7a1695cb1323554ac23", @"/Views/Shared/_PageFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6158612a6d681ad8dc29978efd4454eac227b088", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PageFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 170, true);
            WriteLiteral("<footer class=\"page-footer\" role=\"contentinfo\">\r\n    <div class=\"d-flex align-items-center flex-1 text-muted\">\r\n        <span class=\"hidden-md-down fw-700\">\r\n            ");
            EndContext();
            BeginContext(171, 17, false);
#line 4 "C:\Users\23490\Documents\HMS\HotelManagementSystem\HotelBackEnd\Views\Shared\_PageFooter.cshtml"
       Write(DateTime.Now.Year);

#line default
#line hidden
            EndContext();
            BeginContext(188, 60, true);
            WriteLiteral(" ©Hotel Transylvania\r\n        </span>\r\n    </div>\r\n</footer>");
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