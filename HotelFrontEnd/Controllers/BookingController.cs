using HotelFrontEnd.Models;
using HotelFrontEnd.Services;
using HotelFrontEnd.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Controllers
{
    [Route("Booking")]
    public class BookingController : Controller
    {
        private readonly IHotelServices hotelServices;

        public BookingController(IHotelServices hotelServices)
        {
            this.hotelServices = hotelServices;
        }
        [HttpGet("CheckAvalibility/{RoomTypeId}")]
        public async  Task<IActionResult> CheckAvalibility(string RoomTypeId)
        {
            bool status = await hotelServices.CheckAvalibilityAsync(RoomTypeId);
            if (status)
                return Ok(status);
            return null;
        }
        [HttpGet("SendEmail/{email}/{RoomTypeId}")]
        public async Task<IActionResult> SendEmailForRoomFeaturesAsync(string email,string RoomTypeId)
        {
            //when the user confirm that the room features should be sent
            bool status = await hotelServices.SendEmailForRoomFeaturesAsync(email, RoomTypeId);
            return Ok(status);
        }

        [HttpPost("Book")]
        public async Task<IActionResult> Book(RoomTypeViewModel model)
        {
           //check which room exist using the roomid and get a single room
         // To check availiablity send the features of the room to the request var email
         //onclick tell the user to check its email
         //do booking ....
            //check which room exist using the roomtypeid
            Room roomForBooking = await hotelServices.GetAnyRoomAvailiableForRoomTypeID(model.RoomTypeId);
            if (roomForBooking == null)
            {
               return View(model);
            }
            //mapp model to the roomid and createbookingviewmodel
            

            //mapp model to the bookingviewmodel in the RoomTypeViewModel
            //to be  sent to the api
            var tDays = (model.CheckOutDate - model.CheckInDate).TotalDays;
            var TotaldaysBooked = (int)tDays;

            BookingViewModel book = new BookingViewModel
            {
                MerchantRef = Guid.NewGuid().ToString(),
                Amount = ((int)roomForBooking.Price)*100* TotaldaysBooked,
                Description = roomForBooking.Description,
                CustomerEmail = model.Email,
                CustomerName = model.Email,
                ReturnUrl = "https://localhost:44320/Home/Index",
                Currency = "NGN",
            };
            CreateBookingViewModel _booking = new CreateBookingViewModel
            {
                RoomID = roomForBooking.ID,
                Adults = int.Parse(model.Adult),
                Children = int.Parse(model.Children),
                CheckIn = model.CheckInDate,
                CheckOut = model.CheckOutDate,
                CustomerEmail = model.Email,
                DateCreated = DateTime.Now,
                TotalFee = book.Amount
            };

            var res = await hotelServices.AddBookingAsync(_booking);
            if (!res)
                return RedirectToAction("Home", "Index");

            //send the object to the api returning the "transactionReference","charge","redirectUrl"
            return RedirectToAction("MakePaymentBooking", new 
            {
                MerchantRef = book.MerchantRef,
                Amount = book.Amount,
                Description = book.Description,
                CustomerEmail = book.CustomerEmail,
                Currency = book.Currency,
                CustomerName = book.CustomerName,
                ReturnUrl = book.ReturnUrl,           
            });          
        }
        public async Task<IActionResult> MakePaymentBooking(BookingViewModel book)
        {
            if(book == null)
            {
              return  RedirectToAction("Home", "Index");
            }   
            var bookpay = new BookingViewModel
            {
                Amount = book.Amount,
                Currency = book.Currency,
                Description = book.Description,
                CustomerEmail = book.CustomerEmail,
                CustomerName = book.CustomerName,
                MerchantRef = book.MerchantRef,
                ReturnUrl=book.ReturnUrl,              
            };

            var res = await MakePayment.MakePaymentAsync(bookpay);
            if (res.succeeded)
            {
              return Redirect(res.data.redirectUrl);
            }
            return RedirectToAction("Home", "Index");
        }
        private async Task<bool> AddBookingAsyncs(CreateBookingViewModel bouk)
        {
            var bookdb = await hotelServices.AddBookingAsync(bouk);
            return bookdb;
        }

    }


}
