using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities.InventotyEntities
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceSell { get; set; }
        public decimal CostPrice { get; set; }
        public Vendor Vendor { get; set; }
        public string VendorId { get; set; }
        public IEnumerable<SalesOrder> SalesOrderProducts { get; set; }
    }
}
