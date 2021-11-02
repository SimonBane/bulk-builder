using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class GetAllExercisesHandler : BaseRequestHandler<GetAllExercises, IEnumerable<ExerciseDto>>
    {
        public GetAllExercisesHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        { }

        public override async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercises request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.Exercise.ProjectToAllAsync<ExerciseDto>();
        }
    }
}
