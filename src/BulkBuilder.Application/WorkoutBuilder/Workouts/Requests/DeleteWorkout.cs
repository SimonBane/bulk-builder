using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class DeleteWorkout : IRequest
    {
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
    }
}