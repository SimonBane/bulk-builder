using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Commands.Create
{
    public class CreateExercise : BaseCommandRequest<ExerciseCreateDto, ExerciseDto>
    { }
}
