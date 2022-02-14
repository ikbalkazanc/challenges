﻿using System.ComponentModel.DataAnnotations;

namespace PomeloCase.Core.Models.Dtos.User
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}