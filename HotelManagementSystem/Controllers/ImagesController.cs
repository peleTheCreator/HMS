
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Desk")]
    public class ImagesController : Controller
    {
        private readonly IGenericHotelService<Image> _hotelService;

        public ImagesController(IGenericHotelService<Image> genericHotelService)
        {
            _hotelService = genericHotelService;
        }


        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllImagesJson()
        {
            var images = await _hotelService.GetAllItemsAsync();
            return PartialView("GetAllImagesPartial", images);
        }

        [HttpGet()]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _hotelService.GetItemByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }


            return View(image);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> files)
        {
            var result = await _hotelService.AddImagesAsync(files);
            var AddedImages = new List<string>();
            foreach (var image in result.AddedImages)
            {
                AddedImages.Add(image.Name + " Added Successfully");
            }
            ViewData["AddedImages"] = AddedImages;
            ViewData["UploadErrors"] = result.UploadErrors;
            return View();
        }

        
        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var image = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.RemoveImageAsync(image);
            return RedirectToAction(nameof(Index));
        }
    }
}
