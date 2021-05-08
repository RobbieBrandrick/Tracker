using Microsoft.EntityFrameworkCore;
using Tracker.Core.Models.ExerciseTracker;
using Tracker.Core.Models.Infrastructure.Settings;

namespace Tracker.Core.Data
{
    public class TrackerDbContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public TrackerDbContext()
        {
            _connectionStrings = new ConnectionStrings()
            {
                TrackerDb = "Data Source=TrackerDb.db"
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DatabaseInitializer.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite(_connectionStrings.TrackerDb);
        }

        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
    }
}