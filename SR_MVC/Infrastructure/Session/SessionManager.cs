using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SR_MVC.Infrastructure.Session
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public ClientSession Client
        {
            set { _session.SetString(nameof(Client), JsonSerializer.Serialize(value)); }
            get
            {
                string json = _session.GetString(nameof(Client));
                return (json is null) ? null : JsonSerializer.Deserialize<ClientSession>(json);
            }
        }

        public void Clear()
        {
            _session.Clear();
        }
    }
}
