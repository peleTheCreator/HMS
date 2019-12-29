using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Entities
{
    public class ItemImage
    {
        public string ImageID { get; set; }
        public  Image Image { get; set; }
        public string ItemID { get; set; }
    }
}
