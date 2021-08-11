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
        public DateTime Bdate { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Ccard { get; set; }
        public string Idcard { get; set; }
        public int Book_count { get; set; }
        public bool Is_vip { get; set; }
        public bool Is_healthy { get; set; }
        //public bool IsAdmin { get; set; }
        public string Token { get; set; }

    }
}

