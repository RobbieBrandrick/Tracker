namespace Tracker.Core.Models.ExerciseTracker
{
    public class ExerciseSet
    {
        
        public int ExerciseId { get; set; }
        public int SetId { get; set; }

        public Set Set { get; set; }
        public Exercise Exercise { get; set; }
    }
}