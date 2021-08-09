using SR_DAL.Repos;
using SR_DAL.Data;
using SR_DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;


namespace SR_DAL.Services
{
    public class PlanetService : IPlanetRepo
    {
        private readonly Connection _conn;

        public PlanetService(Connection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Planet> Get()
        {
            Command cmd = new Command("SELECT [Id], [name], [capacity], [distance_m], [distance_h], [fuel_req], [atmosphere], [ports_count] FROM [Planets]", false);
            return _conn.ExecuteReader(cmd, dr => dr.ToPlanet());
        }

        public Planet Get(int id)
        {
            Command cmd = new Command("SELECT [Id], [name], [capacity], [distance_m], [distance_h], [fuel_req], [atmosphere], [ports_count] FROM [Planets] WHERE id = @id;", false);
            cmd.AddParameter("id", id);
            return _conn.ExecuteReader(cmd, dr => dr.ToPlanet()).SingleOrDefault();
        }
    }
}
