using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Desk")]
    public class RoomController : Controller
    {
        private readonly IGenericHotelService<Room> hotelService;

        public RoomController(IGenericHotelService<Room> hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View(hotelService.GetAllTheRoomAndRole());
        }

        [HttpGet()]

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var room = hotelService.GetAllRooms().SingleOrDefault(x => x.ID == id);
            if (room == null)
            {
                return NotFound();
            }
            var ImagesAndFeatures = await hotelService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Features"] = ImagesAndFeatures.Features;
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            var RoomTypes = hotelService.GetAllRoomTypesAsync().GetAwaiter().GetResult();
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name");
            ViewBag.Images = hotelService.GetAllImages();
            var room = new Room();
            ViewData["Features"] = hotelService.PopulateSelectedFeaturesForRoom(room);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room,
            string[] SelectedFeatureIDs, string[] imageIDs)
        {
            if (ModelState.IsValid)
            {
                room.ID = Guid.NewGuid().ToString();
                room.Available = true;
                await hotelService.CreateItemAsync(room);
                hotelService.UpdateRoomFeaturesList(room, SelectedFeatureIDs);
                hotelService.UpdateRoomImagesList(room, imageIDs);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Features"] = hotelService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await hotelService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await hotelService.GetItemByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var RoomTypes = hotelService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "Name", room.RoomType.ID);

            ViewData["Features"] = hotelService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await hotelService.GetRoomFeaturesAndImagesAsync(room);
            //ViewData["Images"] = ImagesAndFeatures.Images;
            ViewData["Images"] = hotelService.GetAllImages();

            return View(room);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Number,RoomTypeID,Price,Available,Description,MaximumGuests")] Room room, string[] SelectedFeatureIDs, string[] imageIDs)
        {
            if (id != room.ID)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    await hotelService.EditItemAsync(room);
                    hotelService.UpdateRoomFeaturesList(room, SelectedFeatureIDs);
                    hotelService.UpdateRoomImagesList(room, imageIDs);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (hotelService.GetItemByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var RoomTypes = hotelService.GetAllRoomTypesAsync().Result;
            ViewData["RoomTypeID"] = new SelectList(RoomTypes, "ID", "ID", room.RoomTypeID);
            ViewData["Features"] = hotelService.PopulateSelectedFeaturesForRoom(room);
            var ImagesAndFeatures = await hotelService.GetRoomFeaturesAndImagesAsync(room);
            ViewData["Images"] = ImagesAndFeatures.Images;
            return View(room);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await hotelService.GetItemByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
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
