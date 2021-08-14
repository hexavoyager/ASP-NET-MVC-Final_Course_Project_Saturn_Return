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

        [DisplayName("Time:")]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDaytime { get; set; }

        [DisplayName("Temperature:")]
        public int Temperature { get; set; }

        [DisplayName("Wind speed:")]
        public string WindSpeed { get; set; }

        [DisplayName("Wind direction:")]
        public string WindDirection { get; set; }

        [DisplayName("Forecast:")]
        public string ShortForecast { get; set; }
    }



}
