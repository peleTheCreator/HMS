using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HotelManagementSystem.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
    }
}