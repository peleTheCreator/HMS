using HotelManagementSystem.Entities.InventotyEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Inventory
{
    public class SalesOrderIndexViewModel
    {
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string ProuctId { get; set; }
        public int Sales { get; set; }
    }
}
