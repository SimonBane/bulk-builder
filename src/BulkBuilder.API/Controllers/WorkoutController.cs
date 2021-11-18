using System.Collections.Generic;
using System.Threading.Tasks;
using BulkBuilder.Application.Common.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BulkBuilder.Application.WorkoutBuilder.Workouts.Requests.WorkoutRequests;

namespace BulkBuilder.API.Controllers
{
    [Route("api/user/{userId}/workout")]
    [ApiController]
    [Authorize]
    public class WorkoutController : BaseController
    {
        public WorkoutController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WorkoutDto>), 200)]
        public async Task<IEnumerable<WorkoutDto>> GetList(int userId) =>
            await ExecuteRequestAsync(GetAllWorkouts(userId));

        [HttpGet("{workoutId}")]
        [ProducesResponseType(typeof(WorkoutDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 404)]
        public async Task<WorkoutDto> GetById(int userId, int workoutId) =>
            await ExecuteRequestAsync(GetWorkout(userId, workoutId));

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 400)]
        public async Task<WorkoutDto> Post(int userId, [FromBody] WorkoutCreateDto model) =>
            await ExecuteRequestAsync(CreateWorkout(userId, model));

        [HttpPut("{workoutId}")]
        [ProducesResponseType(typeof(WorkoutDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 400)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 404)]
        public async Task<WorkoutDto> Put(int userId, int workoutId, [FromBody] WorkoutUpdateDto model) =>
            await ExecuteRequestAsync(UpdateWorkout(userId, workoutId, model));

        [HttpDelete("{workoutId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int userId, int workoutId)
        {
            await ExecuteRequestAsync(DeleteWorkout(userId, workoutId));
            return NoContent();
        }
    }
}