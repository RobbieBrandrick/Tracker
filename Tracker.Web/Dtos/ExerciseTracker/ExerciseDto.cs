using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Web.Dtos.ExerciseTracker
{
    public class ExerciseDto
    {
        public int id { get; set; }
        public string exerciseType { get; set; }
        public SetDto[] sets { get; set; }
    }
}