using HotelManagementSystem.Entities;
using HotelManagementSystem.Services.MessagingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;

        public EmailController(
            RoleManager<IdentityRole> roleManager, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.userManager = userManager;
        }

        public IActionResult SendEmail()
        {
            ViewBag.Status = "false";
            var userrole = roleManager.Roles.ToList();
            ViewBag.UserRole = new SelectList(userrole, "Id", "Name");          
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> SendEmail(EmailRequest emailRequest)
        {
            ViewBag.Status = "true";

            if(emailRequest.UserRoleId != null)
            {
                var rolename =  await roleManager.FindByIdAsync(emailRequest.UserRoleId);
                var  users =    await userManager.GetUsersInRoleAsync(rolename.Name);
                foreach (var user in users)
                {
                   var useremail = await userManager.GetEmailAsync(user);
                    await emailSender.SendEmailAsync(useremail, emailRequest.Subject, emailRequest.Message);
                }

            }
            return View();
        }
    }
}
