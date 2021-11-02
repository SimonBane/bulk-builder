using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class DeleteExerciseHandler : BaseRequestHandler<DeleteExercise, Unit>
    {
        public DeleteExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        { }

        public override async Task<Unit> Handle(DeleteExercise request, CancellationToken cancellationToken)
        {
            var entity = await UnitOfWork.Exercise.GetAsync(request.Id);
            if (entity != null)
            {
                await UnitOfWork.Exercise.DeleteAsync(entity);
                await UnitOfWork.CommitAsync();
            }

            return Unit.Value;
        }
    }
}
