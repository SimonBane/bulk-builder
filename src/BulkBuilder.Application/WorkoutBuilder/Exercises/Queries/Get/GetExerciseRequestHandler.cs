using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Queries.Get
{
    public class GetExerciseRequestHandler : BaseRequestHandler<GetExercise, ExerciseDto>
    {
        public GetExerciseRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        { }

        public override async Task<ExerciseDto> Handle(GetExercise request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.Exercise.ProjectToAsync<ExerciseDto>(e => e.Id == request.Id);
        }
    }
}
