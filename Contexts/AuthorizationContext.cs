using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcapi.Contexts
{
    public class Authorization
    {
        public string username { get; set; }
        public string token { get; set; }
    }

    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext(DbContextOptions<AuthorizationContext> options)
            : base(options) { }
        public List<Authorization> Auths = new List<Authorization>();
    }
}
