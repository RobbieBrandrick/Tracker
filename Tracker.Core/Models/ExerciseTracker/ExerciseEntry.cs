using System;
using System.Collections.Generic;

namespace Tracker.Core.Models.ExerciseTracker
{
    public class ExerciseEntry
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime CreateDate { get; set; }

        public Session Session { get; set; }
        public Exercise Exercise { get; set; }
        public ICollection<SessionSets> Sets { get; set; }
    }
}