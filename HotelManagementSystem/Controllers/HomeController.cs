using HotelManagementSystem.Services.api;
using HotelManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            
            return View();
        }
    }



    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        private readonly IRoomServices roomServices;

        public AdminHomeController(IRoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            DashBorard model = roomServices.GetHotelAdminDashBord();
            return View(model);
        }
    }
    [AllowAnonymous]
    [Route("VisualData")]
    public class VisualizeDataController : Controller
    {
        private readonly IRoomServices roomServices;
        public VisualizeDataController(IRoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

      
        [HttpGet("Data1")]
        public ActionResult HotelDashBoard1()
        {
            List<HotelDashBoardViewModel1> model = roomServices.HotelDashBoard1();
         //   List<HotelDashBoardViewModel1> model = new List<HotelDashBoardViewModel1>();

            return new JsonResult(model);
        }

        [HttpGet("Data2")]
        public ActionResult HotelDashBoard2()
        {
            var model = roomServices.HotelDashBoard2();
            return Ok(model);
        }

        [HttpGet("Data3")]
        public ActionResult HotelDashBoard3()
        {
            var model = roomServices.HotelDashBoard3();
            return Ok(model);
        }
    }
       
    
}
