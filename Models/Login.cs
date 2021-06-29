﻿using System.ComponentModel.DataAnnotations;

namespace MekaShron.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}