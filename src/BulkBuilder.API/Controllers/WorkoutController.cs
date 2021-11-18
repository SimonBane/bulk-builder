using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<WorkoutDto>> GetList(int userId) => await ExecuteRequestAsync(GetAllWorkouts(userId));

        [HttpGet("{workoutId}")]
        public async Task<WorkoutDto> GetById(int userId, int workoutId) =>
            await ExecuteRequestAsync(GetWorkout(userId, workoutId));

        [HttpPost]
        public async Task<WorkoutDto> Post(int userId, [FromBody] WorkoutCreateDto model) =>
            await ExecuteRequestAsync(CreateWorkout(userId, model));
    }
}