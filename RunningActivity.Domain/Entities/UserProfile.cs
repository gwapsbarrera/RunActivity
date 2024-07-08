using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningActivity.Domain.Entities
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Weight { get; set; } // in kg
        public required double Height { get; set; } // in cm
        public required DateTime BirthDate { get; set; }
        public ICollection<RunningActivity>? RunningActivities { get; set; }
    }

}

