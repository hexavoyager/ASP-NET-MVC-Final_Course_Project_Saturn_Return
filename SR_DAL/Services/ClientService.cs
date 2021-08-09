using SR_DAL.Data;
using SR_DAL.Repos;
using SR_DAL.Mappers;
using System.Linq;
using Tools.Connections.Database;


namespace SR_DAL.Services
{
    public class ClientService : IClientRepo
    {
        private readonly Connection _conn;

        public ClientService(Connection conn)
        {
            _conn = conn;
        }

        public Client Get(int id)
        {
            Command cmd = new Command("SELECT [Id], [fname], [lname], [bdate], [email], [ccard], [idcard], [book_count], [is_vip] FROM [Clients] WHERE Id = @id;", false);
            cmd.AddParameter("id", id);
            return _conn.ExecuteReader(cmd, dr => dr.ToClient()).SingleOrDefault();
        }
    }
}
