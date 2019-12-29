//        public async  Task<dynamic> Pay(PaymentViewModel pm)
//        {
//            return await MakePaymentService.PayAsync(pm.CardNumber, pm.month, pm.Year, pm.csv, pm.value);
//        }
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.api;
using HotelManagementSystem.ViewModel.api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.api
{
    [AllowAnonymous]
    [Route("api/Booking")]
    public class ApiBookingController : Controller
    {
        private readonly IBookingService bookingService;
        private readonly IGenericHotelService<Booking> hotelService;

        public ApiBookingController(IBookingService bookingService, IGenericHotelService<Booking> hotelService)
        {
            this.bookingService = bookingService;
            this.hotelService = hotelService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddBookingAsync([FromBody]CreateBookingViewModel book)
        {
            var booking = new Booking 
            {
                CustomerName = book.CustomerEmail,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid().ToString(),
                CustomerEmail = book.CustomerEmail,
                Guests = book.Adults + book.Children,
                TotalFee = book.TotalFee,                
            };
            RedirectToAction("Create", "Booking", new {
                CustomerName = book.CustomerEmail,
                CheckIn = book.CheckIn,
                CheckOut = book.CheckOut,
                DateCreated = DateTime.Now,
                ID = Guid.NewGuid().ToString(),
                CustomerEmail = book.CustomerEmail,
                Guests = book.Adults + book.Children,
                TotalFee = book.TotalFee,
                RoomID = book.RoomID,
            });
           // hotelService.AddBookingForRoom(booking, book.RoomID);
            return Ok(book);
        }

      

    }
}































































