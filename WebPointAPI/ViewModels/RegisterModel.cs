﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebPointAPI.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]

        public string ConfirmPassword { get; set; }
    }
}