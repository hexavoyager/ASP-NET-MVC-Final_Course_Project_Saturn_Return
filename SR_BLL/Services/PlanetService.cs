using SR_BLL.Data;
using SR_BLL.Mappers;
using SR_BLL.Repos;
using DR = SR_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Services
{
    public class PlanetService : IPlanetRepo
    {
        private readonly DR.IPlanetRepo _planetRepo;
        public PlanetService(DR.IPlanetRepo planetRepo)
        {
            _planetRepo = planetRepo;
        }

        public IEnumerable<Planet> Get()
        {
            return _planetRepo.Get().Select(c => c.ToBLL());
        }
        public Planet Get(int id)
        {
            return _planetRepo.Get(id)?.ToBLL();
        }

  
    }
}
