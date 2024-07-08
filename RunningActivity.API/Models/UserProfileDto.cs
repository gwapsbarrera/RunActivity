namespace RunningActivity.API.Models
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public double BMI => Weight / Math.Pow(Height / 100, 2); // BMI = weight (kg) / height^2 (m^2)
    }
}
