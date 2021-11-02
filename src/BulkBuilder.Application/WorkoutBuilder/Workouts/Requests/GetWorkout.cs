using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class GetWorkout : IRequest<WorkoutDto>
    {
        public int Id { get; set; }
    }
}
