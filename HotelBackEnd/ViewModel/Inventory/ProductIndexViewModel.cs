using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.ViewModel.Inventory
{
    public class ProductIndexViewModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceSell { get; set; }
        public decimal CostPrice { get; set; }
        public string VendorName { get; set; }
    }
}
