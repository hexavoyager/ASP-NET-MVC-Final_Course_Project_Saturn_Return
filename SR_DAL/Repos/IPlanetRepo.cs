using SR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_DAL.Repos
{
    public interface IPlanetRepo
    {
        IEnumerable<Planet> Get();
        Planet Get(int id);
    }
}
