using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Requests
{
    public class CreateExercise : BaseCommandRequest<ExerciseCreateDto, ExerciseDto>
    { }
}
