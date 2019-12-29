using HotelFrontEnd.Services;
using HotelFrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFrontEnd.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHotelServices hotelServices;

        public ContactController(IHotelServices hotelServices)
        {
            this.hotelServices = hotelServices;
        }
        [HttpGet()]
        public IActionResult Index(bool status = false)
        {
            ContactViewModel model = new ContactViewModel();
            model.status = status;
            return View(model);
        }
       [HttpPost()]
        public async Task<IActionResult> Create(ContactViewModel contact)
        {
            if(contact == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }
          var status = await  hotelServices.CreateUserContectFormAsync(contact);
            return RedirectToAction("Index", new { status = status});
        }
    }
}
