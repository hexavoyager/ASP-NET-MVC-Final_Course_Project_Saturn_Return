using System;
using System.ComponentModel.DataAnnotations;

namespace SR_MVC.Models.Forms
{
    public class RegisterForm
    {

        [Required]
        [MaxLength(75)]
        [Display(Name = "First Name", Prompt = "Enter your first name.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(75)]
        [Display(Name = "Last Name", Prompt = "Enter your last name.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date", Prompt = "Enter your birth date.")]
        public DateTime Bdate { get; set; }

        [Required]
        [MaxLength(384)]
        [EmailAddress]
        [Display(Name = "Email Address", Prompt = "Enter your email address.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]
        [Display(Name = "Password", Prompt = "Enter a secure password.")]
        public string Pass { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Pass))]
        [Display(Prompt = "Confirm your password.")]
        public string Confirm { get; set; }

        [Required]
        [MaxLength(16)]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card", Prompt = "Enter your credit card number.")]

        public string CCard { get; set; }

        [Required]
        [MaxLength(12)]
        [Display(Name = "ID Card", Prompt = "Enter your ID card number.")]
        public string IdCard { get; set; }
    } 
}
