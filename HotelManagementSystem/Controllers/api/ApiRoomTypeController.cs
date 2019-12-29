using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.api
{
    [Route("api/RoomType")]
    public class ApiRoomTypeController : Controller
    {
        private readonly IGenericHotelService<RoomType> _hotelService;

        public ApiRoomTypeController(IGenericHotelService<RoomType> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            return View(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet("id", Name ="GetRoomType")]
        public async Task<IActionResult> GetItemByIdAsync(string id)
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
            return Ok(roomType);
        }


        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BasePrice,Description,ImageUrl")] RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                roomType.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(roomType);
            return CreatedAtRoute("GetRoomType",
               new { id = roomType.ID },
               roomType);
        }

        [HttpDelete("{id}")]
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
    }
}
