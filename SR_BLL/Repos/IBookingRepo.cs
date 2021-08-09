using SR_BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Repos
{
    public interface IBookingRepo
    {
        Booking Get(int id);
        public void Create(int clientId, bool planet, bool stopover, int planet_portId, DateTime dateA, DateTime dateB, bool is_1stclass, int price);
    }
}
