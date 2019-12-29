using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.Inventory
{
    public class SalesReportViewModel
    {
        public string SalesDate { get; set; }
        public string ProductName { get; set; }
        public string RemainingQty { get; set; }
        public string Price { get; set; }
        public string QtyPerSaleForProduct { get; set; }
        public decimal TotalSaleCostPerProduct { get; set; }
     
    }
    public class OverallSaleReportViewModel
    {
        public IEnumerable<SalesReportViewModel> SalesReportViewModel { get; set; }
        public decimal overalltotalsalecost { get; set; }
        public int TotalSales { get; set; }
    }


    public class ReportViewModels
    {
        public OverallSaleReportViewModel OverallSaleReportViewModel { get; set; }
        public IEnumerable<WhiteBoardTable> WhiteBoardTables { get; set; }
    }
}
