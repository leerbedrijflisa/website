﻿using System.ComponentModel.DataAnnotations;

namespace Lisa.Website.ViewModels
{
    public class CreateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}