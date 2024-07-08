using Microsoft.EntityFrameworkCore;
using RunningActivity.Infrastructure.Data;

namespace RunningActivity.Infrastructure.Services
{
    public class RunningActivityService:IRunningActivityService
    {
        private readonly ApplicationDbContext _context;

        public RunningActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.RunningActivity>> GetAllActivitiesAsync()
        {
            return await _context.RunningActivities.ToListAsync();
        }

        public async Task<Domain.Entities.RunningActivity> GetActivityByIdAsync(int id)
        {
            return await _context.RunningActivities.FindAsync(id);
        }

        public async Task<Domain.Entities.RunningActivity> AddActivityAsync(int userProfileId,Domain.Entities.RunningActivity activity)
        {
            if (userProfileId == 0)
            {
                throw new ArgumentNullException(nameof(userProfileId));
            }

            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }

            activity.UserProfileId = userProfileId;
            _context.RunningActivities.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task UpdateActivityAsync(Domain.Entities.RunningActivity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(int id)
        {
            var activity = await _context.RunningActivities.FindAsync(id);
            if (activity != null)
            {
                _context.RunningActivities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
