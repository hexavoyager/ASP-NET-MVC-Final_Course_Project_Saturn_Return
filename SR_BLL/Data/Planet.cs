using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Data
{
    public class Planet
    {
        public Planet(string name, int capacity, int distance_m, int distance_h, int fuel_req, string atmosphere, int ports_count)
        {
            this.name = name;
            this.capacity = capacity;
            this.distance_m = distance_m;
            this.distance_h = distance_h;
            this.fuel_req = fuel_req;
            this.atmosphere = atmosphere;
            this.ports_count = ports_count;
        }

        internal Planet(int id, string name, int capacity, int distance_m, int distance_h, int fuel_req, string atmosphere, int ports_count)
        {
            this.Id = id;
        }
        public int Id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int distance_m { get; set; }
        public int distance_h { get; set; }
        public int fuel_req { get; set; }
        public string atmosphere { get; set; }
        public int ports_count { get; set; }
    }
}
