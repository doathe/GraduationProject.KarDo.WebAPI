using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Migrations = add-migrations name
/// Db update = update-database


namespace KarDo.Infrastructure.EFCore.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //  DbSets
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }

        // Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Event>(entity => entity.ToTable("events"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
