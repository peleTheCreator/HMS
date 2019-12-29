using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities
{
    public class Room
    {
        public string ID { get; set; }
        [Required]
        public int Number { get; set; }
        public string RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool Available { get; set;}
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public int MaximumGuests { get; set; }
        public virtual ICollection<RoomFeature> Features { get; set; } = new List<RoomFeature>();
        public virtual ICollection<Image> RoomImages { get; set; } = new List<Image>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
