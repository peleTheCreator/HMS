using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.ViewModel.Inventory
{
    public class PurchaseOrderViewModel
    {
        public string PurchaseOrderId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? PurchaseOrderDate { get; set; }
        public decimal TotalCost { get; set; } 
        [Required]
        public decimal CostOfOne { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Product { get; set; }
        public string  Vendor { get; set; }
    }
}
