using HotelFrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    public class RoomTypeViewModel
    {
        [Required]
        public string RoomTypeId { get; set; }
        public List<SelectListItem> RoomTypes { get; set; } = new List<SelectListItem>();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Children { get; set; }
        public string Adult { get; set; }
        public bool Status { get; set; } = false;
        public BookingViewModel Booking { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
