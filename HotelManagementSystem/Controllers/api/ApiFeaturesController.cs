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

namespace HotelManagementSystem.Controllers.api
{
    [Route("api/features")]
    public class ApiFeaturesController : Controller
    {
        private readonly IGenericHotelService<Feature> _hotelService;

        public ApiFeaturesController(IGenericHotelService<Feature> genericHotelService)
        {
            _hotelService = genericHotelService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            return Ok(await _hotelService.GetAllItemsAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetItemByIdAsync(string id)
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


            return Ok(feature);
        }
  
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Icon")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                BadRequest();
            }
                feature.ID = Guid.NewGuid().ToString();
                await _hotelService.CreateItemAsync(feature);
            return Ok(feature);
        }

        [HttpDelete("id")]
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

            return Ok(feature);
        }

    }
}
