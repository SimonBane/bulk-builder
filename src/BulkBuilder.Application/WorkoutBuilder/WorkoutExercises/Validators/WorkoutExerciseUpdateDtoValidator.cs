using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Validators
{
    public class WorkoutExerciseUpdateDtoValidator : AbstractValidator<WorkoutExerciseUpdateDto>
    {
        public WorkoutExerciseUpdateDtoValidator()
        {
            RuleFor(we => we.Id).NotEmpty();
        }
    }
}