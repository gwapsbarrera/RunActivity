namespace RunningActivity.API.Models
{
    public class RunningActivityDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; } // in km
        public int UserProfileId { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public double AveragePace => Duration.TotalMinutes / Distance; // Pace = duration (min) / distance (km)
    }
}
