using Timelinio.Models;
using Microsoft.EntityFrameworkCore;

namespace Timelinio.Data
{
    public class TimelineContext : DbContext
    {
        public TimelineContext(DbContextOptions<TimelineContext> options) : base(options)
        {
        }

        public DbSet<Focus> Focuses { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Event> Events { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Focus>().ToTable("Focus");
            modelBuilder.Entity<Timeline>().ToTable("Timeline");
            modelBuilder.Entity<Event>().ToTable("Event");
        }
    }
}