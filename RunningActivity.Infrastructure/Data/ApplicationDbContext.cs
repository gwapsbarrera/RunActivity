using Microsoft.EntityFrameworkCore;
using RunningActivity.Domain.Entities;
using System.Diagnostics.Metrics;

namespace RunningActivity.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Domain.Entities.RunningActivity> RunningActivities { get; set; }
    }
}
