using System.Collections.Generic;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Web.Dtos.ExerciseTracker
{
    public static class SetExtensions
    {
        public static Set ToDomain(this SetDto dto)
        {
            var result = new Set()
            {
                Id = dto.id,
                Weight = dto.weight,
                Reps = dto.reps,
                RPE = dto.rpe,
            };

            return result;
        }

        public static IList<ExerciseSet> ToDomain(this IEnumerable<SetDto> dtos)
        {
            var result = new List<ExerciseSet>();

            foreach (var dto in dtos)
            {
                result.Add(new ExerciseSet(){ Set = dto.ToDomain() });
            }

            return result;
        }        
    }
}