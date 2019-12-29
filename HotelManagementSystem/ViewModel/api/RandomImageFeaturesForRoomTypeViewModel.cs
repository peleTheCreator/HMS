using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.api
{
    public class RandomImageFeaturesForRoomTypeViewModel
    {
            public string ImagePath { get; set; }
            public IEnumerable<string> Features { get; set; }
        
    }
}
