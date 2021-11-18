using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class UpdateWorkout : IUserOwnedRequest<WorkoutDto>
    {
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        public WorkoutUpdateDto Model { get; set; }
    }
}