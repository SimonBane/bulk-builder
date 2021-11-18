using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Handlers
{
    public class GetWorkoutHandler : BaseRequestHandler<GetWorkout, WorkoutDto>
    {
        private readonly IUserContext _userContext;

        public GetWorkoutHandler(IMapper mapper, IUnitOfWork unitOfWork, IUserContext userContext)
            : base(mapper, unitOfWork)
        {
            _userContext = userContext;
        }

        public override async Task<WorkoutDto> Handle(GetWorkout request, CancellationToken cancellationToken)
        {
            var workout = await UnitOfWork.Workout.GetUserWorkout(request.UserId, request.Id);
            if (workout == null)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }

            var result = Mapper.Map<WorkoutDto>(workout);
            return result;
        }
    }
}