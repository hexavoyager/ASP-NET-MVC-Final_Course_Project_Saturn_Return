using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models.Forms
{
    public class DisplayClient
    {
        [ScaffoldColumn(false)]

        [DisplayName("Id : ")]
        public int Id { get; set; }

        [DisplayName("Firstname : ")]
        public string fname { get; set; }

        [DisplayName("Lastname : ")]
        public string lname { get; set; }

        [DisplayName("Birthdate : ")]
        public DateTime bdate { get; set; }

        [DisplayName("Email : ")]
        public string email { get; set; }

        [DisplayName("Trip count : ")]
        public int book_count { get; set; }

        [DisplayName("VIP status : ")]
        public bool is_vip { get; set; }
    }
}
