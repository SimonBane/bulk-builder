using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Handlers
{
    public class DeleteWorkoutHandler : BaseRequestHandler<DeleteWorkout, Unit>
    {
        public DeleteWorkoutHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public override async Task<Unit> Handle(DeleteWorkout request, CancellationToken cancellationToken)
        {
            var workout = await UnitOfWork.Workout.GetUserWorkout(request.UserId, request.WorkoutId);
            if (workout != null)
            {
                await UnitOfWork.Workout.DeleteAsync(workout);
                await UnitOfWork.CommitAsync();
            }
            
            return Unit.Value;
        }
    }
}