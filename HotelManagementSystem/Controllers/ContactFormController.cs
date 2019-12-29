using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly IRoomServices roomServices;
        public IViewRenderService ViewRender { get; }
        public IEmailSender EmailSender { get; }

        public ContactFormController(IRoomServices roomServices, IViewRenderService viewRender, IEmailSender emailSender)
        {
            this.roomServices = roomServices;
            ViewRender = viewRender;
            EmailSender = emailSender;
        }
        [HttpGet()]
        public async Task<IActionResult> ContactIndex()
        {
            var model= await roomServices.GetContactFormAsync();
            return View(model);
        }

        [HttpGet()]
        public async  Task<IActionResult> SendContactMsg(string Email, string Message, string ContactId)
        {
            //update the contact status to reply
            await roomServices.UpdateContacToStausToReply(ContactId);
            await EmailSender.SendEmailAsync(Email,"Hotel Transylvania", Message);
            return Ok(true);
        }

    }
}
