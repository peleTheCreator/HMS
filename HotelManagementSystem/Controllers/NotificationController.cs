using HotelManagementSystem.Entities;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [AllowAnonymous]
    [Route("Notification/")]
    public class NotificationController : Controller
    {
        private INotificationRepository _notificationRepository;
        private UserManager<ApplicationUser> _userManager;
        public NotificationController(INotificationRepository notificationRepository,
                                        UserManager<ApplicationUser> userManager)
        {
            _notificationRepository = notificationRepository;
            _userManager = userManager;
        }
        [HttpGet("GetNotification")]
        public IActionResult GetNotification()
        {
            var userId = _userManager.GetUserId(User);
            var notification = _notificationRepository.GetUserNotifications(userId);
            return Ok(new { UserNotification = notification, Count = notification.Count });
        }
        [HttpGet("ReadNotification")]
        public IActionResult ReadNotification(int notificationId)
        {

            _notificationRepository.ReadNotification(notificationId, _userManager.GetUserId(User));

            return Ok();
        }
    }
}
