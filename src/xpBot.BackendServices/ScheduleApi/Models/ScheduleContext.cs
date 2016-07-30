using Microsoft.EntityFrameworkCore;

namespace ScheduleApi.Models
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Speaker>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Speaker>()
                .Property(s => s.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Speaker>()
                .Property(s => s.LastName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Speaker>()
                .Property(s => s.Email)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Speaker>()
                .Property(s => s.Twitter)
                .HasMaxLength(50);

            modelBuilder.Entity<Session>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Session>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Session>()
                .Property(s => s.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Session>()
                .Property(s => s.Room)
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<Session>()
                .Property(s => s.Tags)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Session>()
                .Property(s => s.Description)
                .IsRequired();

            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(s => new { s.SessionId, s.SpeakerId });

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(pt => pt.Speaker)
                .WithMany(p => p.SessionSpeakers)
                .HasForeignKey(pt => pt.SpeakerId);

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(pt => pt.Session)
                .WithMany(t => t.SessionSpeakers)
                .HasForeignKey(pt => pt.SessionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
