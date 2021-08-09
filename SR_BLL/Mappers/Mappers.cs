using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B = SR_BLL.Data;
using D = SR_DAL.Data;

namespace SR_BLL.Mappers
{
    internal static class Mappers {
        internal static D.Client ToDAL(this B.Client c)
        {
            return new D.Client()
            {
                Id = c.Id,
                fname = c.fname,
                lname = c.lname,
                bdate = c.bdate,
                email = c.email,
                pass = null,
                ccard = c.ccard,
                idcard = c.idcard,
                book_count = c.book_count,
                is_vip = c.is_vip
            };
        }
        internal static B.Client ToBLL(this D.Client c)
        {
            return new B.Client(c.Id, c.fname, c.lname, c.bdate, c.email, c.pass, c.ccard, c.idcard, c.book_count, c.is_vip);
        }
        internal static B.Planet ToBLL(this D.Planet p)
        {
            return new B.Planet(p.id, p.name, p.capacity, p.distance_m, p.distance_h, p.fuel_req, p.atmosphere, p.ports_count);
        }

        internal static B.Booking ToBLL(this D.Booking b)
        {
            return new B.Booking(b.Id, b.clientId, b.planet, b.stopover, b.planet_portId, b.dateA, b.dateA, b.is_1stclass, b.price);
        }
    }
    
}
