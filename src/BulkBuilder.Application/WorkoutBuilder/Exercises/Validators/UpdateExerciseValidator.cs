using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Validators
{
    public class UpdateExerciseValidator : AbstractValidator<UpdateExercise>
    {
        public UpdateExerciseValidator()
        {
            RuleFor(request => request.Model).NotEmpty();

            RuleFor(request => request.Model.Id).NotEmpty();
            RuleFor(request => request.Model.Name).NotEmpty().MaximumLength(200);
        }
    }
}
