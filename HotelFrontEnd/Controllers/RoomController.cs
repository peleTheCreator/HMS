using HotelFrontEnd.Models;
using HotelFrontEnd.Services;
using HotelFrontEnd.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHotelServices hotelServices;

        public RoomController(IHotelServices hotelServices)
        {
            this.hotelServices = hotelServices;
        }
        public async Task<ActionResult> Index()
        {
            IDictionary<string, DictValue> dict = new Dictionary<string, DictValue>();
            List<decimal> price = new List<decimal>();
            var roomtype =await hotelServices.GetAllRoomType();
            var RoomDescription = new List<string>();
            for (int i = 0; i< roomtype.Count(); i++)
            {
                var RoomTId = roomtype.Select(r => r.ID).ToList()[i];
                 RoomDescription = await hotelServices.GetRoomDescriptionForType(RoomTId);
                 var RoomTypeName = roomtype.Select(r => r.Name).ToList()[i];
                var feature = await hotelServices.GetRoomFeatures(RoomTId);
                var roomtypePrice = await hotelServices.GetRoomTypesPrice(RoomTId);
                dict.Add(RoomTypeName, new DictValue {Features = feature, Path =RoomTId});
                price.Add(roomtypePrice);
            }
            var model = new RoomViewModel
            { 
              Dict = dict,
              Price = price,
              RoomDescription = RoomDescription,
            };
            return View(model);
        }       
    }
}



