using AutoMapper;
using RunningActivity.Domain.Entities;

namespace RunningActivity.API.Profiles
{
    public class RunningActivitiesMappingProfile: Profile
    {
        public RunningActivitiesMappingProfile()
        {
            CreateMap<Domain.Entities.RunningActivity, Models.RunningActivityDto>().ReverseMap();
            CreateMap<Models.RunningActivityForCreationDto, Domain.Entities.RunningActivity>();
            CreateMap<Models.RunningActivityForUpdateDto, Domain.Entities.RunningActivity>();
        }
    }
}
