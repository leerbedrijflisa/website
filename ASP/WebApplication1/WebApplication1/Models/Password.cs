using System;
using System.ComponentModel.DataAnnotations;

namespace Lisa.Website
{
    public class Password
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}