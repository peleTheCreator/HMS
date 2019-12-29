using HotelFrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Controllers
{
    public class ImageController : Controller
    {
        public ImageController(IHotelServices hotelServices)
        {
            HotelServices = hotelServices;
        }

        public IHotelServices HotelServices { get; }

        public async Task<IActionResult> Index()
        {
            var baseurl = "https://localhost:44349/api/room/image/";
            var paths = new List<string>();
            //get all imageids from the api
            var imgids =await  HotelServices.GetAllInageIdsAsync();
            foreach (var img in imgids)
            {
               var fullpath = baseurl + img;
               paths.Add(fullpath);
            }
            return View(paths);
        }
    }
}
