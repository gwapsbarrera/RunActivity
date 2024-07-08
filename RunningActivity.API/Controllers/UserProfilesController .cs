using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RunningActivity.API.Models;
using RunningActivity.Domain.Entities;
using RunningActivity.Infrastructure.Services;

namespace RunningActivity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProfilesController> _logger;

        public UserProfilesController(
            IUserProfileService userProfileService, 
            IMapper mapper,
            ILogger<UserProfilesController> logger
            )
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetAllProfiles()
        {
            try
            {
                var profiles = await _userProfileService.GetAllProfilesAsync();
                return Ok(_mapper.Map<IEnumerable<UserProfileDto>>(profiles));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception was thrown", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetProfileById(int id)
        {
            var profile = await _userProfileService.GetProfileByIdAsync(id);
            if (profile == null)
            {
                _logger.LogInformation($"User with id {id} wasn't found when accessing user profile.");
                return NotFound();
            }
            return Ok(_mapper.Map<UserProfileDto>(profile));
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileDto>> AddProfile(UserProfileForCreationDto profile)
        {
            var userProfileEntity = _mapper.Map<UserProfile>(profile);
            var userProfileToReturn = await _userProfileService.AddProfileAsync(userProfileEntity);
            return CreatedAtAction(nameof(GetProfileById), new { id = userProfileToReturn.Id }, userProfileToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, UserProfileForUpdateDto profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            var userProfileEntity = _mapper.Map<UserProfile>(profile);
            await _userProfileService.UpdateProfileAsync(userProfileEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _userProfileService.DeleteProfileAsync(id);
            return NoContent();
        }
    }
}
