using System;

namespace SR_DAL.Data
{
    public class Client
    {
        public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public DateTime bdate { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string ccard { get; set; }
        public string idcard { get; set; }
        public int book_count { get; set; }
        public bool is_vip { get; set; }
        public bool is_healthy { get; set; }
    }
}
