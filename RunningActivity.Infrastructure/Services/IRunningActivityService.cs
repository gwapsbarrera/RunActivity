namespace RunningActivity.Infrastructure.Services
{
    public interface IRunningActivityService
    {
        Task<IEnumerable<Domain.Entities.RunningActivity>> GetAllActivitiesAsync();
        Task<Domain.Entities.RunningActivity> GetActivityByIdAsync(int id);

        Task<Domain.Entities.RunningActivity> AddActivityAsync(int userProfileId,
            Domain.Entities.RunningActivity activity);
        Task UpdateActivityAsync(Domain.Entities.RunningActivity activity);
        Task DeleteActivityAsync(int id);
    }
}
