using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ViewModels
{
    public class LoginView
    {
        [Required]
        [Display(Name="Username")]
        public string LoginID { get; set; }

        [Required]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}