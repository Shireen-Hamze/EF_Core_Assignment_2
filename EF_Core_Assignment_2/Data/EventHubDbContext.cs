using EF_Core_Assignment_2.Data.Configurations;
using EF_Core_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Assignment_2.Data
{
    public class EventHubDbContext : DbContext
    {
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=EventHubDB;Trusted_Connection=True;");
        }
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply configurations for OrganizerProfile
            modelBuilder.ApplyConfiguration(
                new OrganizerProfileConfiguration());
            // Organizer - Event (One-to-Many)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId)
                .IsRequired();
            // BadgeNumber Unique
            modelBuilder.Entity<Badge>()
                .HasIndex(b => b.BadgeNumber)
                .IsUnique();
            // Attendee - Badge (One-to-One)
            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId)
                .IsRequired();
            
            // Event Properties Configuration
            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired();

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsRequired();
        }
    }
}
