using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Services
{
    public static class RenderRazorViewToString
    {
        //public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        //{
        //    controller.ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        ViewEngineResult viewResult;
        //        viewResult = Microsoft.AspNetCore.Mvc.ViewEngines..Engines.FindPartialView(controller.ControllerContext, viewName);
        //        var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
        //        viewResult.View.RenderAsync(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}
    }
}
