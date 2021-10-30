using System.Threading.Tasks;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BulkBuilder.Application.WorkoutBuilder.Exercises.ExerciseRequests;

namespace BulkBuilder.API.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : BaseController
    {
        public ExerciseController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> List() => Ok(await ExecuteRequestAsync(GetAll));

        [HttpGet("{id}", Name = "GetExercise")]
        public async Task<ExerciseDto> Get(int id) => await ExecuteRequestAsync(GetById(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExerciseCreateDto model)
        {
            var result = await ExecuteRequestAsync(Create(model));
            return Created("GetExercise", result);
        }
    }
}
