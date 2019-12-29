using HotelManagementSystem.Entities;
using HotelManagementSystem.Infastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        Task Create(Notification notification);
        void ReadNotification(int notificationId, string userId);
    }
    public class NotificationRepository : INotificationRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<SignalServer> hubContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppDbContext _context { get; }


        public NotificationRepository(AppDbContext context, UserManager<ApplicationUser> userManager, 
            IHubContext<SignalServer> hubContext, RoleManager<IdentityRole> roleManager)
                                       
        {
            _context = context;
            this.userManager = userManager;
            this.hubContext = hubContext;
            this.roleManager = roleManager;
        }

        public async  Task Create(Notification notification)
        {
            _context.Notifications.Add(notification);
          await  _context.SaveChangesAsync();
            //TODO: Assign notification to users
            var User = await userManager.GetUsersInRoleAsync("Admin");
            var userDesk = await userManager.GetUsersInRoleAsync("Desk");
            User.ToList().AddRange(userDesk.ToList());

              //var users = await userManager.Users.Select(u=>u.Id).ToListAsync();
  
            var userNotification = new List<NotificationApplicationUser>();
            foreach (var id in User.Select(ap=>ap.Id).ToList())
            {
                userNotification.Add(new NotificationApplicationUser { ApplicationUserId = id,
                NotificationId = notification.Id });
             }
            _context.UserNotifications.AddRange(userNotification);
            await    _context.SaveChangesAsync();
           await hubContext.Clients.All.SendAsync("displayNotification", "");

        }

        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return _context.UserNotifications.Where(u => u.ApplicationUserId.Equals(userId) && !u.IsRead)
                                            .Include(n => n.Notification)
                                            .ToList();
        }

        public void ReadNotification(int notificationId, string userId)
        {
            var notification = _context.UserNotifications
                                       .FirstOrDefault(n => n.ApplicationUserId.Equals(userId)
                                       && n.NotificationId == notificationId);
            notification.IsRead = true;
            _context.UserNotifications.Update(notification);
            _context.SaveChanges();

        }

       
    }

}
