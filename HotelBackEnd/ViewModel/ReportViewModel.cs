using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.ViewModel
{
    public class ReportViewModel
    {
        public DateTime DateCreated { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }       
        public int RoomNumber { get; set; }
        public decimal TotalFee { get; set; }
    }
}
