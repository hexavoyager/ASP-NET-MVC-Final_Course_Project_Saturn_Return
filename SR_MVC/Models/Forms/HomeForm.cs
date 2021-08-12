using Microsoft.AspNetCore.Mvc.Rendering;
using SR_BLL.Data;
using SR_MVC.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models.Forms
{
    public class HomeForm

    {

        public HomeForm()
        {
            dateA = DateTime.Now.Date;
            dateB = DateTime.Now.Date;
        }
        
        [Required]
        [DisplayName("Destination planet:")]
        //[PlanetIdValidationAttribute]
        public int planet { get; set; }

        [Required]
        [DisplayName("Jupiter stop-over:")]
        public bool stopover { get; set; }

        [Required]
        [DisplayName("Departure date:")]
        //[Range(typeof(DateTime), "1/1/1945", "1/1/2123", ErrorMessage = "Date is out of range!")]
        public DateTime dateA { get; set; }

        [Required]
        [DisplayName("Return date:")]
        //[Range(typeof(DateTime), "1/1/1945", "1/1/2123", ErrorMessage = "Date is out of range!")]
        public DateTime dateB { get; set; }

        [Required]
        [DisplayName("1st class option:")]
        public bool is_1stclass { get; set; }
        public IEnumerable<SelectListItem> Planets { get; set; }
    };
}
