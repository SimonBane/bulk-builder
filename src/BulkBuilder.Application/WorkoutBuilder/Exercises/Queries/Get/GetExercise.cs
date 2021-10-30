using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Queries.Get
{
    public class GetExercise : IRequest<ExerciseDto>
    {
        public int Id { get; set; }
    }
}
