using System;
using System.ComponentModel.DataAnnotations;

namespace SR_MVC.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Bdate { get; set; }

        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]
        public string Pass { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Pass))]
        public string Confirm { get; set; }

        [Required]
        [MaxLength(16)]
        [DataType(DataType.CreditCard)]
        public string CCard { get; set; }

        [Required]
        [MaxLength(12)]
        public string IdCard { get; set; }
    } 
}
