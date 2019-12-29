using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel
{
    public class HotelDashBoardViewModel1
    {
        //line chart
        public string room { get; set; }
        public int totalPerRoomBookedForTheDay { get; set; }
    }

    public class HotelDashBoardViewModel2
    {
        //columchart
        public int totalPerRoomBookedForTheWeek { get; set; }
        public string room { get; set; }
    }
    public class HotelDashBoardViewModel3
    {
        //pie chart
        public int totalPerRoomBookedForMonth { get; set; }
        public string room { get; set; }
    }

    public class DashBorard
    {
        public decimal TotalFeesForTheDay { get; set; }
        public decimal TotalFeesForTheWeek { get; set; }
        public decimal TotalFeesForTheMonth { get; set; }
        public int TotalRoomBookedForToday { get; set; }
        public int TotalRoomBookedForTheWeek { get; set; }
        public int TotalRoomBookedForTheMonth { get; set; }
    }
}
