using SR_BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Repos
{
    public interface IPlanetRepo
    {
        public IEnumerable<Planet> Get();
        public Planet Get(int id);
    }
}
