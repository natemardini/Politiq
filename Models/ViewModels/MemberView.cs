﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ViewModels
{
    public class MemberView
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Login ID")]
        public string LoginID { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}