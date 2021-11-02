using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Requests
{
    public class DeleteExercise : IRequest
    {
        public int Id { get; set; }
    }
}
