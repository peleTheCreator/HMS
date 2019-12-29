using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.api
{
    public class CreateBookingViewModel
    {
        public string RoomID { get; set; }      
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal TotalFee { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
    }
}
