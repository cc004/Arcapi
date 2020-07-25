using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcapi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Arcapi.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
