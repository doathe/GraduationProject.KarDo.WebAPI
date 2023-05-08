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

            //// Id Column tipine bak !!! Guid = uniqueidentifier ?
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("user");

            //    entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
            //    entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            //    entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            //    entity.Property(i => i.UserName).HasColumnName("username").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            //    entity.Property(i => i.Email).HasColumnName("email").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            //    entity.Property(i => i.PasswordHash).HasColumnName("password").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                
            //    entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
            //    entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
