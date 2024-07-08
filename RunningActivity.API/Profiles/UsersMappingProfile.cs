using AutoMapper;
using RunningActivity.Domain.Entities;

namespace RunningActivity.API.Profiles
{
    public class UsersMappingProfile:Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<UserProfile, Models.UserProfileDto>().ReverseMap();
            CreateMap<Models.UserProfileForCreationDto, UserProfile>();
            CreateMap<Models.UserProfileForUpdateDto, UserProfile>();
        }  
    }
}
