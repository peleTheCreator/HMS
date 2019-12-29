

namespace HotelFrontEnd.Models
{
    public class Room
    {
        public string ID { get; set; }     
        public int Number { get; set; }
        public string RoomTypeID { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set;}
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
      
    }
}
