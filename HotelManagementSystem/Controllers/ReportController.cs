using HotelManagementSystem.Services;
using HotelManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var model = new List<ReportViewModel>();
            return View(model);
        }

        [HttpPost()]
        public IActionResult Index([Required]DateTime ReportFrom, [Required] DateTime ReportTo)
        {
            if(ReportFrom > ReportTo)
            {
                return BadRequest();
            }
            IEnumerable<ReportViewModel> model = reportService.GenerateBookingReport(ReportFrom, ReportTo);
            ViewBag.TotalRoomBooked = reportService.TotalRoomBooked(ReportFrom, ReportTo);
            ViewBag.Fee = reportService.Fee(ReportFrom, ReportTo);
            return View(model);
        }
    }
}
