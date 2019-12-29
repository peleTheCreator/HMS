using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.ViewModel.Inventory
{
    public class ProductEditViewModel
    {
        public string PurchaseOrderId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        [Required]
        public decimal CostOfOne { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string VendorId { get; set; }

    }
}
