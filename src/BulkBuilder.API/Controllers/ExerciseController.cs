using System.Collections.Generic;
using System.Threading.Tasks;
using BulkBuilder.Application.Common.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BulkBuilder.Application.WorkoutBuilder.Exercises.Requests.ExerciseRequests;

namespace BulkBuilder.API.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : BaseController
    {
        public ExerciseController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDto>), 200)]
        public async Task<IEnumerable<ExerciseDto>> GetList() => await ExecuteRequestAsync(GetAllExercises);

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExerciseDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 404)]
        public async Task<ExerciseDto> Get(int id) => await ExecuteRequestAsync(GetExercise(id));

        [HttpPost]
        [ProducesResponseType(typeof(ExerciseDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 400)]
        public async Task<ExerciseDto> Post([FromBody] ExerciseCreateDto model) => await ExecuteRequestAsync(CreateExercise(model));

        [HttpPut]
        [ProducesResponseType(typeof(ExerciseDto), 200)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 400)]
        [ProducesResponseType(typeof(HandledResponseWrapper), 404)]
        public async Task<ExerciseDto> Put([FromBody] ExerciseUpdateDto model) => await ExecuteRequestAsync(UpdateExercise(model));

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            await ExecuteRequestAsync(DeleteExercise(id));
            return NoContent();
        }
    }
}
