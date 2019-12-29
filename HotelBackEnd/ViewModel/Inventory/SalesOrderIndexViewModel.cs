using HotelBackEnd.Entities.InventotyEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnds.ViewModel.Inventory
{
    public class SalesOrderIndexViewModel
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProuctId { get; set; }
        [Required]
        public string Sales { get; set; }
    }
}
