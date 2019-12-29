using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelFrontEnd.Models;
using HotelFrontEnd.Services;
using HotelFrontEnd.ViewModel;

namespace HotelFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelServices hotelServices;

        public HomeController(IHotelServices hotelServices)
        {
            this.hotelServices = hotelServices;
        }
        public async Task<IActionResult> Index(bool status = false)
        {
            var rt = await hotelServices.GetRoomTypeAsync();
            return View(new RoomTypeViewModel { RoomTypes = rt.RoomTypes, Status = status });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
