using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities.InventotyEntities
{
    public class PurchaseOrder
    {
        [Key]
        public string PurchaseOrderId { get; set; }
        public string Number { get; set; }
        public DateTimeOffset? PurchaseOrderDate { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public decimal CostOfOne { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
    }
}
