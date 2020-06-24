using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_dash.Models
{
    public class DashDbContext : DbContext
    {
        public DashDbContext(DbContextOptions<DashDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
