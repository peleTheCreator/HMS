
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    public class BookingViewModel
    {
        public string Currency { get; set; } = "NGN";
        public string MerchantRef { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } 
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string IntegrationKey { get; } = "69ff846462204f90b0f7d0199af801df";
        public string ReturnUrl { get; set; }
    }
}
