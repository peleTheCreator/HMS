using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities.InventotyEntities
{
    public class SalesOrder
    {
        public string SalesOrderId { get; set; }
        public int TotalSales { get; set; }
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public DateTime SalesDate { get; set; }
    }

   
}

