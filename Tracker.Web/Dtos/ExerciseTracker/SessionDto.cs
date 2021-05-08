namespace Tracker.Web.Dtos.ExerciseTracker
{
    public class SessionDto
    {
        public int id { get; set; }
        public ExerciseDto[] exercises { get; set; }
    }
}