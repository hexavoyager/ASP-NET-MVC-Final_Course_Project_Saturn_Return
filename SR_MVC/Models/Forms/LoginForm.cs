using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        [Display(Name="Email:", Prompt = "Enter your email address.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name ="Password:", Prompt = "Enter your password.")]
        public string Pass { get; set; }
    }
}
