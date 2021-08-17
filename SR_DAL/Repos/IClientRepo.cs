using SR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_DAL.Repos
{
    public interface IClientRepo
    {
        Client Get(int id);
        Client GetByEmail(string email);
        void Register(Client client);
        void UpdateCount(int id, int book_count);
        Client Login(string email, string pass);
        
    }
}
