using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.InventotyEntities
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public string Number { get; set; }
        public decimal PriceSell { get; set; }
        public decimal CostPrice { get; set; }
       // public Guid ProductId { get; set; }
       // public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime InventoryDate { get; set; } = DateTime.Now;
       // public PurchaseOrder PurchaseOrder { get; set; }       
    }  
}
