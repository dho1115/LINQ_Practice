using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Linq_Practice.Models;
using Linq_Practice.Models.Agents;

namespace Linq_Practice.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<hotel>().HasKey(x => x.name);
        }

        public DbSet<Linq_Practice.Models.person> persons { get; set; }

        public DbSet<Linq_Practice.Models.hotel> hotels { get; set; }

        public DbSet<Linq_Practice.Models.location> locations { get; set; }

        public DbSet<Linq_Practice.Models.Agents.AgentInfo> AgentInfo { get; set; }

        public DbSet<Linq_Practice.Models.Agents.bid> bid { get; set; }

    }
}
