using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using KarDo.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Migrations = add-migration name
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
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventJoin> UserEventJoins { get; set; }

        // Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Event>(entity => entity.ToTable("events"));
            modelBuilder.Entity<ApplicationUser>(entity => entity
                .HasMany(i => i.Events)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .HasConstraintName("user_event_id_fk"));

            modelBuilder.Entity<UserEventJoin>(entity =>
            {
                entity.ToTable("user_event_join");

                // One-To-Many Relation (User - UserEventJoin)
                entity.HasOne(c => c.User)
                    .WithMany(p => p.UserEventJoins)
                    .HasForeignKey(p => p.UserId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("user_event_join_id_fk");

                // One-To-Many Relation (Event - UserEventJoin)
                entity.HasOne(c => c.Event)
                    .WithMany(p => p.EventUserJoins)
                    .HasForeignKey(p => p.EventId)
                    .HasPrincipalKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_user_join_id_fk");

                entity.HasKey(p => new { p.UserId, p.EventId }); // Yeni birincil anahtar
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
