using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Infrastructure.Session
{
    public class ClientSession
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //public bool IsAdmin { get; set; }
        public string Token { get; set; }

    }
}

