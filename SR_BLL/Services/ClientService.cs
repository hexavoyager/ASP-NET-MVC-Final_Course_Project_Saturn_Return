using SR_BLL.Data;
using SR_BLL.Mappers;
using SR_BLL.Repos;
using DR = SR_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;


namespace SR_BLL.Services
{
    public class ClientService : IClientRepo
    {
        private readonly DR.IClientRepo _clientRepo;
        public ClientService(DR.IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }
        public Client Get(int id)
        {
            return _clientRepo.Get(id)?.ToBLL();
        }

        public Client GetByEmail(string email)
        {
            return _clientRepo.GetByEmail(email).ToBLL();
        }
        public void Register(Client client)
        {
            _clientRepo.Register(client.ToDAL());
        }

        public void UpdateCount(int id, int book_count)
        {
            _clientRepo.UpdateCount(id, book_count);
        }
        public Client Login(string email, string pass)
        {
            return _clientRepo.Login(email, pass)?.ToBLL();
        }
    }
}
