using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace RunningActivity.Domain.Entities
{
    [Table("RunningActivities")]
    public class RunningActivity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public required string Location { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required double Distance { get; set; } // in km
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
       
    }
}
