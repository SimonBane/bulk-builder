using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class GetWorkout : IUserOwnedRequest<WorkoutDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
