using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using HotelManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Desk")]
    public class BookingsController : Controller
    {
        private readonly IGenericHotelService<Booking> hotelService;
        private readonly INotificationRepository notificationRepository;

        public BookingsController(IGenericHotelService<Booking> hotelService,
            INotificationRepository notificationRepository)
        {
            this.hotelService = hotelService;
            this.notificationRepository = notificationRepository;
        }

        [HttpGet()]
        public  IActionResult Index()
        {
            var model =  hotelService.GetAllBooking();
            
            return View(model);
        }

        [HttpGet()]
        public  IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookType =  hotelService.GetBookingById(id);


            if (bookType == null)
            {
                return NotFound();
            }
            return  View(bookType);
        }
        [Authorize(Policy = "CeateBookingPolicy")]
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

        [Authorize(Policy = "CeateBookingPolicy")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("CheckIn,CheckOut,Completed," +
            "CustomerAddress,CustomerCity,CustomerEmail," +
            "CustomerName,CustomerPhone,OtherRequests,Guests")]
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

            var notification = new Notification
            {
                Text = $"a {room.RoomType.Name} was booked at {DateTime.Now.ToLocalTime()}",
            };

            notificationRepository.Create(notification).GetAwaiter().GetResult();
            return  RedirectToAction(nameof(Index));
        }
        [Authorize(Policy = "EditBookingPolicy")]
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

        [Authorize(Policy = "EditBookingPolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit([Bind("CheckIn,Paid,CheckOut," +
            "CustomerAddress,CustomerCity,ID,Completed,DateCreated,CustomerEmail," +
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
                     hotelService.UpdatBookingForRoom(booking, RoomID);
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
        [Authorize(Policy = "DeleteBookingPolicy")]
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
        [Authorize(Policy = "DeleteBookingPolicy")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //var room = hotelService.UpdateRoomToBeUnAvailiable(id);
            var booking = await hotelService.GetItemByIdAsync(id);
            await hotelService.DeleteItemAsync(booking);
            return RedirectToAction(nameof(Index));
        }
    }
}
