using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using BulkBuilder.Domain.Entities;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Handlers
{
    public class CreateWorkoutHandler : BaseRequestHandler<CreateWorkout, WorkoutDto>
    {
        public CreateWorkoutHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public override async Task<WorkoutDto> Handle(CreateWorkout request, CancellationToken cancellationToken)
        {
            var newWorkout = Mapper.Map<Workout>(request.Model);
            newWorkout.UserId = request.UserId;

            await UnitOfWork.Workout.InsertAsync(newWorkout);
            await UnitOfWork.CommitAsync();

            var createdWorkout = await UnitOfWork.Workout.GetUserWorkout(request.UserId, newWorkout.Id);
            return Mapper.Map<WorkoutDto>(createdWorkout);
        }
    }
}