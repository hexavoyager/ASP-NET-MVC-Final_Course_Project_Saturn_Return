using SR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_DAL.Mappers
{
    internal static class DataRecord
    {
        internal static Client ToClient(this IDataRecord r)
        {
            return new Client()
            {
                //Id = (int)r["Id"],
                fname = (string)r["fname"],
                lname = (string)r["lname"],
                bdate = (DateTime)r["bdate"],
                email = (string)r["email"],
                pass = null,
                ccard = (string)r["ccard"],
                idcard = (string)r["idcard"],
                book_count = (int)r["book_count"],
                is_vip = (bool)r["is_vip"],
                is_healthy = (bool)r["is_healthy"]
            };
        }
        internal static Planet ToPlanet(this IDataRecord r)
        {
            return new Planet()
            {
                id = (int)r["Id"],
                name = (string)r["name"],
                capacity = (int)r["capacity"],
                distance_m = (int)r["distance_m"],
                distance_h = (int)r["distance_h"],
                fuel_req = (int)r["fuel_req"],
                atmosphere = (string)r["atmosphere"],
                ports_count = (int)r["ports_count"]
            };
        }

        internal static Booking ToBooking(this IDataRecord r)
        {
            return new Booking()
            {
                Id = (int)r["Id"],
                clientId = (int)r["clientId"],
                planet = (int)r["planet"],
                stopover = (bool)r["stopover"],
                planet_portId = (int)r["planet_portId"],
                dateA = (DateTime)r["dateA"],
                dateB = (DateTime)r["dateB"],
                is_1stclass = (bool)r["is_1stclass"],
                price = (int)r["price"]
            };
        }
    }

}
