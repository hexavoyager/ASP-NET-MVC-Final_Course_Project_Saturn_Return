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
        
        [Required(ErrorMessage = "You must select a destination planet.")]
        [DisplayName("Destination planet:")]
        public int planet { get; set; }

        [DisplayName("Jupiter stop-over:")]
        public bool stopover { get; set; }

        [Required(ErrorMessage = "You must select a departure date.")]
        [DisplayName("Departure date:")]
        [DateTimeRange]
        public DateTime dateA { get; set; }

        [Required(ErrorMessage = "You must select a return date.")]
        [DisplayName("Return date:")]
        [DateTimeRange]
        public DateTime dateB { get; set; }

        [DisplayName("1st class option:")]
        public bool is_1stclass { get; set; }
        public IEnumerable<SelectListItem> Planets { get; set; }
    };
}
