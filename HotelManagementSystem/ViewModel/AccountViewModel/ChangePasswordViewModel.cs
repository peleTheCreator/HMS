﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.ViewModel.AccountViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassWord { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
