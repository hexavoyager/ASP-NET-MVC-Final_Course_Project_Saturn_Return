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
    class BookingService : IBookingRepo

    {
        private readonly DR.IBookingRepo _bookingRepo;
        public BookingService(DR.IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void Create(int clientId, bool planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price)
        {
            throw new NotImplementedException();
        }

        public Booking Get(int id)
        {
            return _bookingRepo.Get(id)?.ToBLL();
        }
    }
}
