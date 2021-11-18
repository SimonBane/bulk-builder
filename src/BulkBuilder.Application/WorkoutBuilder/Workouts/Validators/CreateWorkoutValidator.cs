using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Validators;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Validators
{
    public class CreateWorkoutValidator : AbstractValidator<CreateWorkout>
    {
        public CreateWorkoutValidator()
        {
            RuleFor(cw => cw.UserId).NotEmpty();

            RuleFor(cw => cw.Model.Name).NotEmpty().MaximumLength(200);

            RuleForEach(cw => cw.Model.Exercises).SetValidator(new WorkoutExerciseCreateDtoValidator());
        }
    }
}