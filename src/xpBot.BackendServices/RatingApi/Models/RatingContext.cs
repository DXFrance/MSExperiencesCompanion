using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RatingApi.Models
{
    public class RatingContext : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }

        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(r => new { r.SessionId, r.UserId });

            modelBuilder.Entity<Rating>()
                .Property(r => r.Notation)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
