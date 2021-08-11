using System;


namespace SR_DAL.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int clientId { get; set; }      
        public int planet { get; set; }
        public bool stopover { get; set; }
        public int planet_portId { get; set; }
        public DateTime dateA { get; set; }
        public DateTime dateB { get; set; }
        public bool is_1stclass { get; set; }
        public int price { get; set; }

    }
}
