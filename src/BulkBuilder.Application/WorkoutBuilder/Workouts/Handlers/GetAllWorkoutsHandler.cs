using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Handlers
{
    public class GetAllWorkoutsHandler : BaseRequestHandler<GetAllWorkouts, IEnumerable<WorkoutDto>>
    {
        public GetAllWorkoutsHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public override async Task<IEnumerable<WorkoutDto>> Handle(GetAllWorkouts request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.Workout.ProjectToAllAsync<WorkoutDto>(w => w.UserId == request.UserId);
        }
    }
}