using SR_BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_BLL.Repos
{
    public interface IClientRepo
    {
        Client Get(int id);
    }
}
