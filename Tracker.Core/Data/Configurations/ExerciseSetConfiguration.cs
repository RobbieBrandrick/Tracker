using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Data.Configurations
{
    public class ExerciseSetConfiguration : IEntityTypeConfiguration<ExerciseSet>
    {
        public void Configure(EntityTypeBuilder<ExerciseSet> builder)
        {
            builder
                .HasKey(e => new {e.SetId, e.ExerciseId});

            builder
                .HasOne(e => e.Exercise)
                .WithMany(e => e.Sets);

            builder
                .HasOne(e => e.Set)
                .WithOne(e => e.Exercise);
        }
    }
}