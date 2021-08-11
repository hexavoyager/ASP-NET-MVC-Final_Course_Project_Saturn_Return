using SR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_DAL.Repos
{
    public interface IBookingRepo
    {
        Booking Get(int id);
        void Create(int clientId, int planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price);
    }
}
