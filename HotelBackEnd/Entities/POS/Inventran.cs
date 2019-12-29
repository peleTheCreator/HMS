using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities.POS
{
    public class Inventran
    {
        public Guid InvenTranId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public string Category { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset? InvenTranDate { get; set; } = DateTime.Now;
    }
}
