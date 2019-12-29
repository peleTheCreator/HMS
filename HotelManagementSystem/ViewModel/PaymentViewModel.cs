using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel
{
    public class PaymentViewModel
    {
        public string CardNumber { get; set; }
        public int month { get; set; }
        public int Year { get; set; }
        public string csv { get; set; }
        public int value { get; set; }
    }
}
