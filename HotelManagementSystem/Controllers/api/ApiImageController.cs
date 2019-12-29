
using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.api
{
    [Route("api/Images")]
    public class ApiImageController : Controller
    {
        private readonly IGenericHotelService<Image> _hotelService;

        public ApiImageController(IGenericHotelService<Image> genericHotelService)
        {
            _hotelService = genericHotelService;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetItemByIdAsync(string id)
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

        [HttpPost()]
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
        public async Task<IActionResult> Delete(string id)
        {
            var image = await _hotelService.GetItemByIdAsync(id);
            await _hotelService.RemoveImageAsync(image);
            return NoContent();
        }
    }
}
