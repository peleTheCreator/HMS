using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities.POS
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
}
