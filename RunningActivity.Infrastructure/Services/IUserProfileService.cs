using RunningActivity.Domain.Entities;

namespace RunningActivity.Infrastructure.Services
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> GetAllProfilesAsync();
        Task<UserProfile> GetProfileByIdAsync(int id);
        Task<UserProfile> AddProfileAsync(UserProfile profile);
        Task UpdateProfileAsync(UserProfile profile);
        Task DeleteProfileAsync(int id);
        Task<bool> IsUserProfileExists(int id);
    }
}
