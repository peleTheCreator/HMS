using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBackEnd.Entities
{
    public class Booking
    {
        public string ID { get; set; }
        public string RoomID { get; set; }
        public  Room Room { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
        public bool Paid { get; set; }
        public bool Completed { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationId")]
        public  ApplicationUser User { get; set; }
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerCity { get; set; }

        public string OtherRequests { get; set; }
    }
}