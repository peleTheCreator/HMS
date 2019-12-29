using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.api
{
    public class CheckBookingAvailableViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Children { get; set; }
        public string Adult { get; set; }
        public string RoomTypeId { get; set; }
        
    }
}
