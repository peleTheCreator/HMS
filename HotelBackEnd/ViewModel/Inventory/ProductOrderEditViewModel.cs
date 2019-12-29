using HotelBackEnd.Entities.InventotyEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.ViewModel.Inventory
{
    public class ProductOrderEditViewModel
    {
        public string PurchaseOrderId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? PurchaseOrderDate { get; set; } = DateTime.Now;
        public decimal TotalCost { get; set; }
        [Required]
        public decimal CostOfOne { get; set; }
        [Required]
        public int Quantity { get; set; }
        public IEnumerable<Product> Product { get; set; }
        public string ProductId { get; set; }

    }
}
