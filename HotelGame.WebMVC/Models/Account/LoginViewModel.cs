﻿using System.ComponentModel.DataAnnotations;

namespace HotelGame.WebMVC.Models.Account
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Lütfen Eposta hesabınızı yazınız")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi yazınız")]
        public string Password { get; set; }

    }
}
