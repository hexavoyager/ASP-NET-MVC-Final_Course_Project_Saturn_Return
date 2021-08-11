using SR_DAL.Data;
using SR_DAL.Mappers;
using SR_DAL.Repos;
using System;
using System.Linq;
using Tools.Connections.Database;

namespace SR_DAL.Services
{
    public class BookingService : IBookingRepo

    {
        private readonly Connection _conn;
        public BookingService(Connection conn)
        {
            _conn = conn;
        }
        public void Create(int clientId, int planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price)
        {
            Command cmd = new Command("AddBooking", true);
            cmd.AddParameter("clientId", clientId);
            cmd.AddParameter("planet", planet);
            cmd.AddParameter("stopover", stopover);
            cmd.AddParameter("planet_portId", planet_portId);
            cmd.AddParameter("dateA", dateA);
            cmd.AddParameter("dateB", dateB);
            cmd.AddParameter("is_1stclass", is_1stclass);
            cmd.AddParameter("price", price);

            _conn.ExecuteNonQuery(cmd);
        }

        public Booking Get(int id)
        {
            Command cmd = new Command("SELECT Id, clientId, planet, stopover, planet_portId, dateA, dateB, is_1stclass, price FROM [Bookings] WHERE Id = @id", false);
            cmd.AddParameter("id", id);
            return _conn.ExecuteReader(cmd, dr => dr.ToBooking()).SingleOrDefault();
        }
    }
}
