using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    public class UserContact
    {
        [Key]
        public string UserContactId { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime DateTime { get; set; }
        public bool Reply { get; set; } = false;
        public string ReplyMessage { get; set; }
    }
}

