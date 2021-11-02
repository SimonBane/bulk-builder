using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class GetExerciseHandler : BaseRequestHandler<GetExercise, ExerciseDto>
    {
        public GetExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        { }

        public override async Task<ExerciseDto> Handle(GetExercise request, CancellationToken cancellationToken)
        {
            var result = await UnitOfWork.Exercise.ProjectToAsync<ExerciseDto>(e => e.Id == request.Id);
            if (result == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}
