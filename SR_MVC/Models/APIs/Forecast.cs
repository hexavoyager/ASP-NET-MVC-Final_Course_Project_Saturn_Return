using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Models.APIs
{
    public class Geometry
    {
        public string type { get; set; }
        public List<int> coordinates { get; set; }
    }

    public class Distance
    {
        public double value { get; set; }
        public string unitCode { get; set; }
    }

    public class Bearing
    {
        public int value { get; set; }
        public string unitCode { get; set; }
    }

    public class Properties
    {
        public string city { get; set; }
        public string state { get; set; }
        public Distance distance { get; set; }
        public Bearing bearing { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string cwa { get; set; }
        public string forecastOffice { get; set; }
        public string gridId { get; set; }
        public int gridX { get; set; }
        public int gridY { get; set; }
        public string forecast { get; set; }
        public string forecastHourly { get; set; }
        public string forecastGridData { get; set; }
        public string observationStations { get; set; }
        public RelativeLocation relativeLocation { get; set; }
        public string forecastZone { get; set; }
        public string timeZone { get; set; }
        public string radarStation { get; set; }
    }

    public class RelativeLocation
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Root
    {
        [JsonProperty("@context")]
        public List<object> Context { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }



}
