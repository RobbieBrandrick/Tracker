using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tracker.Core.Data.Configurations;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Data
{
    public static class DatabaseInitializer
    {

        public static void SeedData(ModelBuilder modelBuilder)
        {

            DatabaseConfiguration.SetUpConfigurations(modelBuilder);
            
            SeedExerciseTypes(modelBuilder);

        }

        private static void SeedExerciseTypes(ModelBuilder modelBuilder)
        {

            int id = 1;
            
            modelBuilder.Entity<ExerciseType>().HasData(new List<ExerciseType>()
            {
                new ExerciseType() { Id = id++, Name = "Squat"},
                new ExerciseType() { Id = id++, Name = "Bench"},
                new ExerciseType() { Id = id++, Name = "Deadlift"},
                new ExerciseType() { Id = id++, Name = "Pullups"},
            });

        }
    }
}