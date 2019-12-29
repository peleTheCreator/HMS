using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Desk")]
    public class FeaturesController : Controller
    {
        private readonly IGenericHotelService<Feature> _hotelService;

        public FeaturesController(IGenericHotelService<Feature> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet()]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _hotelService.GetItemByIdAsync(id);


            if (feature == null)
            {
                return NotFound();
            }


            return View(feature);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Icon")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                feature.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(feature);
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _hotelService.GetItemByIdAsync(id);

            var rooms = _hotelService.GetAllRoomsWithFeature(id);
            ViewData["RoomsWithFeature"] = rooms;
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Icon")] Feature feature)
        {
            if (id != feature.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotelService.EditItemAsync(feature);
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
            return View(feature);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _hotelService.GetItemByIdAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var feature = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.DeleteItemAsync(feature);
            return RedirectToAction(nameof(Index));
        }
    }
}
