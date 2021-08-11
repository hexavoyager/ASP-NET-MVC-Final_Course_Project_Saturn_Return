using SR_BLL.Data;
using SR_BLL.Repos;
using SR_BLL.Mappers;
using DR = SR_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Services
{
    public class BookingService : IBookingRepo

    {
        private readonly DR.IBookingRepo _bookingRepo;
        public BookingService(DR.IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        public void Create(int clientId, int planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price)
        {
           _bookingRepo.Create(clientId, planet, stopover, planet_portId, dateA, dateB, is_1stclass, price);
        }

        public Booking Get(int id)
        {
            return _bookingRepo.Get(id)?.ToBLL();
        }
    }
}
