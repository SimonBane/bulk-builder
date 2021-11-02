using System.Threading.Tasks;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BulkBuilder.API.Controllers
{
    [Route("api/workout")]
    [ApiController]
    public class WorkoutController : BaseController
    {
        public WorkoutController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet("{id}")]
        public async Task<WorkoutDto> GetById(int id) => await ExecuteRequestAsync(new GetWorkout { Id = id });
    }
}
