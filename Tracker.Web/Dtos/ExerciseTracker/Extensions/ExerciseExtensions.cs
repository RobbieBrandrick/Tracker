using System.Collections.Generic;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Web.Dtos.ExerciseTracker
{
    public static class ExerciseExtensions
    {
        public static Exercise ToDomain(this ExerciseDto dto)
        {
            var result = new Exercise()
            {
                Id = dto.id,
                Sets = dto.sets.ToDomain()
            };

            return result;
        }

        public static IList<Exercise> ToDomain(this IEnumerable<ExerciseDto> dtos)
        {
            var result = new List<Exercise>();

            foreach (var dto in dtos)
            {
                result.Add(dto.ToDomain());
            }

            return result;
        }
    }
}