using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models
{
    public class DisplayPlanet
    {
        [DisplayName("Planet")]
        public string Name { get; set; }

        [DisplayName("Atmosphere")]
        public string Atmosphere { get; set; }

        [DisplayName("Capacity")]
        public int Capacity { get; set; }

        [DisplayName("Distance (M miles)")]
        public int Distance_m { get; set; }

        [DisplayName("Distance (hours)")]
        public int Distance_h { get; set; }

        [DisplayName("No. of spaceports")]
        public int Ports_count { get; set; }
    }
}
