using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class CreateExerciseHandler : BaseRequestHandler<CreateExercise, ExerciseDto>
    {
        public CreateExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        { }

        public override async Task<ExerciseDto> Handle(CreateExercise request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Exercise>(request.Model);

            await UnitOfWork.Exercise.InsertAsync(entity);
            await UnitOfWork.CommitAsync();

            return await UnitOfWork.Exercise.ProjectToAsync<ExerciseDto>(e => e.Id == entity.Id);
        }
    }
}
