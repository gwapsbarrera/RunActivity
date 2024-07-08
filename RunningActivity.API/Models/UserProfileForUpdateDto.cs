namespace RunningActivity.API.Models
{
    public class UserProfileForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm
        public DateTime BirthDate { get; set; }
    }
}
