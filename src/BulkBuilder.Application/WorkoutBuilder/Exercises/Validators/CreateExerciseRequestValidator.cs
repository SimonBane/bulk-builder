using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Validators
{
    public class CreateExerciseRequestValidator : AbstractValidator<CreateExercise>
    {
        public CreateExerciseRequestValidator()
        {
            RuleFor(request => request.Model).NotNull();

            RuleFor(request => request.Model.Name).NotEmpty().MaximumLength(200);
        }
    }
}
