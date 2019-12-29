using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    public class RoomViewModel
    {
        public IDictionary<string, DictValue> Dict { get; set; }
        public List<decimal> Price { get; set; }
        public List<string> RoomDescription { get; set; } = new List<string>();
    }

    public class DictValue
    {
        public List<string> Features { get; set; }
        public string Path { get; set; }
    }
}