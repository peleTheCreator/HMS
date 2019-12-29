using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IGenericHotelService<RoomType> _hotelService;

        public RoomTypeController(IGenericHotelService<RoomType> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        // GET: RoomTypes
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        // GET: RoomTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _hotelService.GetItemByIdAsync(id);


            if (roomType == null)
            {
                return NotFound();
            }

            var rooms = _hotelService.GetAllRooms().Where(x => x.RoomTypeID == id);
            ViewData["CategoryRooms"] = rooms;
            return View(roomType);
        }

        // GET: RoomTypes/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                roomType.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(roomType);
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (id != roomType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.EditItemAsync(roomType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_hotelService.GetItemByIdAsync(id) == null)
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
            return View(roomType);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _hotelService.GetItemByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string ProductId)
        {
            var roomType = await _hotelService.GetItemByIdAsync(ProductId);
            await _hotelService.DeleteItemAsync(roomType);
            return RedirectToAction(nameof(Index));
        }
    }
}

