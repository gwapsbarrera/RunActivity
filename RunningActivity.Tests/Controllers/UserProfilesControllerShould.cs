

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NLog;
using RunningActivity.API.Controllers;
using RunningActivity.API.Models;
using RunningActivity.API.Profiles;
using RunningActivity.Domain.Entities;
using RunningActivity.Infrastructure.Services;
using ILogger = NLog.ILogger;

namespace RunningActivity.Tests.Controllers
{
    public class UserProfilesControllerShould:BaseControllerTest
    {
        private readonly Mock<IUserProfileService> _mockUserProfileService;
        private readonly Mock<ILogger<UserProfilesController>> _mockLogger;
        private readonly UserProfilesController _sut;

        public UserProfilesControllerShould()
        {
            _mockUserProfileService = new Mock<IUserProfileService>();
            _mockLogger = new Mock<ILogger<UserProfilesController>>();
            _sut = new UserProfilesController(
                _mockUserProfileService.Object,
                _mapper,
                _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllProfiles()
        {
            //Arrange
            var userProfiles = new List<UserProfile>
            {
                new UserProfile { Id = 1, Name = "User1",Weight = 60,Height = 171,BirthDate = DateTime.Now},
                new UserProfile { Id = 2, Name = "User2",Weight = 62,Height = 175,BirthDate = DateTime.Now }
            };

            _mockUserProfileService.Setup(x => x.GetAllProfilesAsync())
                .ReturnsAsync(userProfiles);

            //Act
            var result = await _sut.GetAllProfiles();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<UserProfileDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);

        }
    }
}
