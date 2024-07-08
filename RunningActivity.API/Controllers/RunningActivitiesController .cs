using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RunningActivity.API.Models;
using RunningActivity.Domain.Entities;
using RunningActivity.Infrastructure.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RunningActivity.API.Controllers
{
    [ApiController]
    [Route("api/userprofiles/{userProfileId}/runningactivities")]
    public class RunningActivitiesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IRunningActivityService _runningActivityService;
        private readonly IMapper _mapper;
        private readonly ILogger<RunningActivitiesController> _logger;

        public RunningActivitiesController(
            IUserProfileService userProfileService,
            IRunningActivityService runningActivityService, 
            IMapper mapper,
            ILogger<RunningActivitiesController> logger)
        {
            _userProfileService = userProfileService;
            _runningActivityService = runningActivityService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunningActivityDto>>> GetAllActivities(int userProfileId)
        {
            try
            {
                if (!await _userProfileService.IsUserProfileExists(userProfileId))
                {
                    _logger.LogInformation($"User with id {userProfileId} wasn't found when accessing running activities.");
                    return NotFound();
                }
                var activities = await _runningActivityService.GetAllActivitiesAsync();
                return Ok(_mapper.Map<IEnumerable<RunningActivityDto>>(activities));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception was thrown", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RunningActivityDto>> GetActivityById(int userProfileId,int id)
        {
            if (!await _userProfileService.IsUserProfileExists(userProfileId))
            {
                _logger.LogInformation($"User with id {userProfileId} wasn't found when accessing running activities.");
                return NotFound();
            }
            var activity = await _runningActivityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                _logger.LogInformation($"User with id {userProfileId} cannot found running activity id {id} when accessing running activities.");
                return NotFound();
            }
            return Ok(_mapper.Map<RunningActivityDto>(activity));
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Entities.RunningActivity>> AddActivity(int userProfileId, RunningActivityForCreationDto activity)
        {
            if (!await _userProfileService.IsUserProfileExists(userProfileId))
            {
                _logger.LogInformation($"User with id {userProfileId} wasn't found when adding running activities.");
                return NotFound();
            }

            var runningActivityEntity = _mapper.Map<Domain.Entities.RunningActivity>(activity);
            var runningActivityToReturn = await _runningActivityService.AddActivityAsync(userProfileId,runningActivityEntity);
            return CreatedAtAction(nameof(GetActivityById), new 
                { userProfileId= runningActivityToReturn.UserProfileId, id = runningActivityToReturn.Id }, runningActivityToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int userProfileId,int id, RunningActivityForUpdateDto activity)
        {
            if (!await _userProfileService.IsUserProfileExists(userProfileId))
            {
                _logger.LogInformation($"User with id {userProfileId} wasn't found when updating running activities.");
                return NotFound();
            }
            if (userProfileId != activity.UserProfileId)
            {
                return BadRequest();
            }

            if (id != activity.Id)
            {
                return BadRequest();
            }
            var activityEntity = _mapper.Map<Domain.Entities.RunningActivity>(activity);
            await _runningActivityService.UpdateActivityAsync(activityEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int userProfileId,int id)
        {
            if (!await _userProfileService.IsUserProfileExists(userProfileId))
            {
                _logger.LogInformation($"User with id {userProfileId} wasn't found when deleting running activities.");
                return NotFound();
            }
            await _runningActivityService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
