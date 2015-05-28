using System;
using System.ComponentModel.DataAnnotations;

namespace Lisa.Website
{
    public class ChangePass
    {
        public string Id { get; set; }
        public string ReturnUrl { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordNew { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}