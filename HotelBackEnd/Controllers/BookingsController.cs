
using HotelBackEnd.Entities;
using HotelBackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBackEnd.Controllers
{
    [Authorize(Roles = "Admin,Desk")]
    public class BookingsController : Controller
    {
        private readonly IGenericHotelService<Booking> hotelService;

        public BookingsController(IGenericHotelService<Booking> hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet()]
        public  IActionResult Index()
        {
            var model =  hotelService.GetAllBooking();
            return View(model);
        }

        [HttpGet()]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookType = await hotelService.GetItemByIdAsync(id);


            if (bookType == null)
            {
                return NotFound();
            }
            return  View(bookType);
        }
        [HttpGet()]
        public  IActionResult Create(string roomID)
        {
            var room =  hotelService.GetRoomByID(roomID);
            ViewBag.Room = room;
            ViewBag.RoomID = roomID;

            var status = hotelService.GetBookingStatus(roomID);
            if (status)
                ViewBag.Status = "Status:Completed";
            else
                ViewBag.Status = "Status:Pending";

            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("CheckIn,TotalFee,CheckOut,Completed," +
            "CustomerAddress,CustomerCity,CustomerEmail," +
            "CustomerName,CustomerPhone,DateCreated,OtherRequests,Guests")]
        Booking booking, string RoomID)
        {
            var room = hotelService.GetRoomByID(RoomID);
            ViewBag.Room = room;
            try
            {

                if (booking != null)
                { 
                booking.ID = Guid.NewGuid().ToString();
                hotelService.AddBookingForRoom(booking, RoomID);
                }
            }
            catch (Exception)
            {

                throw;
            }
           return  RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =  hotelService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit([Bind("CheckIn,Paid,CheckOut," +
            "CustomerAddress,CustomerCity,CustomerEmail," +
            "CustomerName,CustomerPhone,OtherRequests,Guests")]
        Booking booking, string RoomID)
        {
           var room = hotelService.GetRoomByID(RoomID);
            if (room == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     hotelService.AddBookingForRoom(booking, RoomID);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roomType = await hotelService.GetItemByIdAsync(id);
            await hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }
    }
}
