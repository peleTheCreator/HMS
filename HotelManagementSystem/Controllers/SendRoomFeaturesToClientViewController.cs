
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services.api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class SendRoomFeaturesToClientViewController : Controller
    {
        private readonly IRoomServices roomServices;

        public SendRoomFeaturesToClientViewController(IRoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

        public IActionResult SendRoomFeaturesToClientView(string RoomTypeId)
        {
            SendRoomFeaturesToClientViewModel model = roomServices.GetSendRoomFeature(RoomTypeId);
            return View(model);
        }
    }

    public class SendRoomFeaturesToClientViewModel
    {
        public List<string> Features { get; set; } = new List<string>();
        public string Path { get; set; }
        public string Email { get; set; }

    }
}
