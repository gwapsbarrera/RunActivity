namespace RunningActivity.API.Models
{
    public class RunningActivityForCreationDto
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; } // in km
    }
}
