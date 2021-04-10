namespace Tracker.Core.Models.Infrastructure.Settings
{
    public class ConnectionStrings
    {
        public const string ConfigSection = "ConnectionStrings";
        public string TrackerDb { get; set; }
    }
}