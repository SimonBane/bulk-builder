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
    public class UpdateExerciseHandler : BaseRequestHandler<UpdateExercise, ExerciseDto>
    {
        public UpdateExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        { }

        public override async Task<ExerciseDto> Handle(UpdateExercise request, CancellationToken cancellationToken)
        {
            var entity = await UnitOfWork.Exercise.GetAsync(request.Model.Id);
            if (entity == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Exercise does not exist!");
            }

            Mapper.Map(request.Model, entity);

            await UnitOfWork.Exercise.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();

            return await UnitOfWork.Exercise.ProjectToAsync<ExerciseDto>(e => e.Id == entity.Id);
        }
    }
}
