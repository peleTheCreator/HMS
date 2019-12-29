using System;
using System.Collections.Generic;

namespace HotelManagementSystem.ViewModel.Inventory
{
    public class InventoryWhiteBoardViewModel
    {
        public string PurchaseOrderToday { get; set; }
        public string PurchaseOrderThisWeek { get; set; }
        public string PurchaseOrderThisMonth { get; set; }
        public string PurchaseOrderCostToday { get; set; }
        public string PurchaseOrderCostThisWeek { get; set; }
        public string PurchaseOrderCostThisMonth { get; set; }
        public string SalesToDayQuantity { get; set; }
        public string SalesToDayPrice { get; set; }
        public string SalesThisWeekPrice { get; set; }
        public string SalesThisWeekQuantity { get; set; }
        public string SalesThisMonthPrice { get; set; }
        public string SalesThisMonthQuantity { get; set; }
        public string TotalEarningToday { get; set; }
        public string TotalEarningThisWeek { get; set; }
        public string TotalEarningThisMonth { get; set; }
        public string TotalEarnings { get; set; }
        public string TotalProducts { get; set; }
        public string TotalVendor { get; set; }
    }

    public class WhiteBoardTable
    {
        public string Product { get; set; }
        public string QtyRemaining { get; set; }
        public string TotalQty{ get; set; }
        public string LastPurchaseDate{ get; set; }
    }
}
