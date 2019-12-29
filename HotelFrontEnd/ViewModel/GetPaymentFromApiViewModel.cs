using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    public class Data
    {
        public string TransactionReference { get; set; }
        public int charge { get; set; }
        public string redirectUrl { get; set; }
    }
    public class GetPaymentModel
    {
        public Data data { get; set; }
        public bool succeeded { get; set; }
    }
}
