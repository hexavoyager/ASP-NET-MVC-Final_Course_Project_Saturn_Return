using System;


namespace SR_BLL.Data
{
    public class Booking
    {
        public Booking(int clientId, bool planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price)
        {
            this.clientId = clientId;
            this.planet = planet;
            this.stopover = stopover;
            this.planet_portId = planet_portId;
            this.dateA = dateA;
            this.dateB = dateB;
            this.is_1stclass = is_1stclass;
            this.price = price;
        }

        internal Booking(int Id, int clientId, bool planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price)
        {
            this.Id = Id;
        }

        public int Id { get; set; }
        public int clientId { get; set; }
        public bool planet { get; set; }
        public bool stopover { get; set; }
        public int planet_portId { get; set; }
        public DateTime dateA { get; set; }
        public DateTime dateB { get; set; }
        public bool is_1stclass { get; set; }
        public int price { get; set; }

    }
}
