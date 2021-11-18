using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Validators
{
    public class WorkoutExerciseCreateDtoValidator : AbstractValidator<WorkoutExerciseCreateDto>
    {
        public WorkoutExerciseCreateDtoValidator()
        {
            RuleFor(we => we.ExerciseId).NotEmpty();
        }
    }
}