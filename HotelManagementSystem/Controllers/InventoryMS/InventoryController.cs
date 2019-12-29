using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Services.Inventory;
using HotelManagementSystem.ViewModel.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers.InventoryMS
{
    [Authorize(Roles = "Admin,StoreKeeper")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }
        [HttpGet()]
        public async Task<ActionResult> Index()
        {
            InventoryWhiteBoardViewModel model = await inventoryService.CreateWhiteBoard();
            return View(model);
        }
        [HttpGet()]
        public async Task<ActionResult> Report()
        {        
            IEnumerable<WhiteBoardTable> whiteBoards = await inventoryService.CreateWhiteBoardReport();
            ReportViewModels model = new ReportViewModels();
            model.WhiteBoardTables = whiteBoards;
            ViewBag.Report = "true";
            return View(model);
        }
        [HttpPost()]
        public async  Task<ActionResult> Report(DateTime SalesReportReportFrom, DateTime SalesReportReportTo)
        {
            var query = await inventoryService.CreateSaleReport(SalesReportReportFrom, SalesReportReportTo);
            ReportViewModels model = new ReportViewModels();
            model.OverallSaleReportViewModel = query;
            ViewBag.Report = "false";
            return View(model);
        }
    }
}