using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface IReportService
    {
        IEnumerable<ReportViewModel> GenerateBookingReport(DateTime reportFrom, DateTime reportTo);
        int TotalRoomBooked(DateTime reportFrom, DateTime reportTo);
        decimal Fee(DateTime reportFrom, DateTime reportTo);
    }
    public class ReportService : IReportService
    {
        private readonly AppDbContext context;

        public ReportService(AppDbContext context)
        {
            this.context = context;
        }

        public decimal Fee(DateTime reportFrom, DateTime reportTo)
        {
            decimal totalfee = 0;
            var book = context.Bookings.Include(b => b.Room)
                  .Where(b => b.DateCreated >= reportFrom && b.DateCreated <= reportTo).ToList();
            foreach(var b in book)
            {
                totalfee = b.TotalFee + totalfee;
            }
            return totalfee;
        }

        public IEnumerable<ReportViewModel> GenerateBookingReport(DateTime reportFrom, DateTime reportTo)
        {
            var book = context.Bookings.Include(b => b.Room);
            List<ReportViewModel> model = new List<ReportViewModel>();
            model = book.OrderBy(b => b.ID)
                .Select(b => new ReportViewModel
                {
                    DateCreated = b.DateCreated,
                    CustomerName = b.CustomerName,
                    CustomerPhone = b.CustomerPhone,
                    RoomNumber = b.Room.Number,    
                    TotalFee = b.TotalFee
                }).Where(b => b.DateCreated >= reportFrom.Date && b.DateCreated <= reportTo.Date)
                .ToList();
            return (model);
        }

        public int TotalRoomBooked(DateTime reportFrom, DateTime reportTo)
        {
            var book = context.Bookings.Include(b => b.Room).
                Where(b => b.DateCreated >= reportFrom && b.DateCreated <= reportTo).ToList().Count();
            return book;
        }
    }
}
