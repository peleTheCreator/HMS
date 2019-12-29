using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Services.MessagingService
{
    public class EmailRequest
    {   
        [Required]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Email { get; set; }
        public string UserRoleId { get; set; }
        // public IFormFile Attachment { get; set; }
    }
}
