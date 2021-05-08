using System;

using System.Collections.Generic;

namespace Tracker.Core.Models.ExerciseTracker
{
    public class Exercise
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ExerciseTypeId { get; set; }
        public DateTime CreateDate { get; set; }

        public Session Session { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public ICollection<ExerciseSet> Sets { get; set; }
    }
}