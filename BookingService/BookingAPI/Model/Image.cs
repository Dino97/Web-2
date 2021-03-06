﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        [Required]
        public string ImageLocation { get; set; }
    }
}
