using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Infrastructure.Session
{
    public interface ISessionManager
    {
        ClientSession Client { get; set; }
        void Clear();
    }
}
