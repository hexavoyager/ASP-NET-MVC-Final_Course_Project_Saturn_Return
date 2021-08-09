using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_DAL.Data
{
    public class Planet
    {
        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int distance_m { get; set; }
        public int distance_h { get; set; }
        public int fuel_req { get; set; }
        public string atmosphere { get; set; }
        public int ports_count { get; set; }
    }
}
