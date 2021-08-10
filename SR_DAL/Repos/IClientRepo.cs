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
        void Register(Client client);
        Client Login(string email, string pass);
    }
}
