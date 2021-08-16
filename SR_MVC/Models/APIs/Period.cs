using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models.APIs
{
    public class Period
    {
        public int Number { get; set; }

        [DisplayName("Day")]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDaytime { get; set; }

        [DisplayName(" Temp °F")]
        public int Temperature { get; set; }

        [DisplayName("Wind Mph ")]
        public string WindSpeed { get; set; }

        [DisplayName("Wind")]
        public string WindDirection { get; set; }

        [DisplayName("Details")]
        public string ShortForecast { get; set; }
    }



}
