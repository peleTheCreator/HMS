﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.api
{
    public class ContactViewModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
    }
}
