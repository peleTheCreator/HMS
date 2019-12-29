using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Entities
{
    public class Feature
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        public virtual List<RoomFeature> Rooms { get; set; }
    }
}