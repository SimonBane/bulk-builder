using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using static System.Net.HttpStatusCode;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Handlers
{
    public class UpdateWorkoutHandler : BaseRequestHandler<UpdateWorkout, WorkoutDto>

    {
        public UpdateWorkoutHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public override async Task<WorkoutDto> Handle(UpdateWorkout request, CancellationToken cancellationToken)
        {
            var workout = await UnitOfWork.Workout.GetUserWorkout(request.UserId, request.WorkoutId);
            if (workout == null)
                throw new HttpException(NotFound, "Workout does not exist!");

            Mapper.Map( request.Model, workout);
            await UnitOfWork.CommitAsync();

            return Mapper.Map<WorkoutDto>(workout);
        }
    }
}