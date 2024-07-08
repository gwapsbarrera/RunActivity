using Microsoft.EntityFrameworkCore;
using RunningActivity.Domain.Entities;
using RunningActivity.Infrastructure.Data;

namespace RunningActivity.Infrastructure.Services
{
    public class UserProfileService: IUserProfileService
    {
        private readonly ApplicationDbContext _context;

        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserProfile>> GetAllProfilesAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetProfileByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task<UserProfile> AddProfileAsync(UserProfile profile)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task UpdateProfileAsync(UserProfile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfileAsync(int id)
        {
            var profile = await _context.UserProfiles.FindAsync(id);
            if (profile != null)
            {
                _context.UserProfiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsUserProfileExists(int id)
        {
            return await _context.UserProfiles
                .AnyAsync(u => u.Id == id);
        }
    }
}
