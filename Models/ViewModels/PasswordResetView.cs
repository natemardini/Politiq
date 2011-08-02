using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ViewModels
{
    public class PasswordResetView
    {
        [Required]
        [Display(Name="Username")]
        public string LoginID { get; set; }
    }
}