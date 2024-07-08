namespace RunningActivity.API.Models
{
    public class RunningActivityForUpdateDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; } // in km
        public int UserProfileId { get; set; }
    }
}
