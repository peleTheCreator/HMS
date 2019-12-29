﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFrontEnd.Models
{
    public class RoomType
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal BasePrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
    }
}