using System.Collections.Generic;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Web.Dtos.ExerciseTracker
{
    public static class SessionExtensions
    {

        public static Session ToDomain(this SessionDto dto)
        {

            var result = new Session()
            {
                Exercises = dto.exercises.ToDomain(),
            };

            return result;

        }
        
    }
}