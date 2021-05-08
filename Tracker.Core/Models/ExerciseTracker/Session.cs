using System;
using System.Collections.Generic;

namespace Tracker.Core.Models.ExerciseTracker
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long Duration { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}