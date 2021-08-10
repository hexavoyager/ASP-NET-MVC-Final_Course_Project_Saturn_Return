using System;

namespace SR_BLL.Data
{
    public class Client
    {
        public Client(string fname, string lname, DateTime bdate, string email, string pass, string ccard, string idcard, int book_count, bool is_vip, bool is_healthy)
        {
            this.fname = fname;
            this.lname = lname;
            this.bdate = bdate;
            this.email = email;
            this.pass = pass;
            this.ccard = ccard;
            this.idcard = idcard;
            this.book_count = book_count;
            this.is_vip = is_vip;
            this.is_healthy = is_healthy;
        }
        internal Client(int id, string fname, string lname, DateTime bdate, string email, string pass, string ccard, string idcard, int book_count, bool is_vip, bool is_healthy)
            : this(fname, lname, bdate, email, pass, ccard, idcard, book_count, is_vip, is_healthy)
        {
            this.Id = id;
        }
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
