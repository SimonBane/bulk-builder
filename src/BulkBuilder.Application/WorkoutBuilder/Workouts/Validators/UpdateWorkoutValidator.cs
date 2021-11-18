using System.Data;
using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Validators;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Requests;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Validators
{
    public class UpdateWorkoutValidator : AbstractValidator<UpdateWorkout>
    {
        public UpdateWorkoutValidator()
        {
            RuleFor(uw => uw.WorkoutId).NotEmpty();
            RuleFor(uw => uw.UserId).NotEmpty();

            RuleFor(uw => uw.Model).NotEmpty();
            RuleFor(uw => uw.Model.Name).NotEmpty().MaximumLength(200);
            RuleForEach(uw => uw.Model.Exercises).SetValidator(new WorkoutExerciseUpdateDtoValidator());
        }
    }
}