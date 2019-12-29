
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.InventotyEntities
{
    public class ProductPurchaseOrderTracking
    {
        [Key]
        public int ProductPurchaseOrderTrackerId { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int TotalPoductQty { get; set; }
        public int RemainingProductQty { get; set; }
        public DateTime DateTime { get; set; }
        public string PurchaseOrderId { get; set; }
    }
}
