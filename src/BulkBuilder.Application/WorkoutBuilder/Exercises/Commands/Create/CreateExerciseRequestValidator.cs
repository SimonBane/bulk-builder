using FluentValidation;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Commands.Create
{
    public class CreateExerciseRequestValidator : AbstractValidator<CreateExercise>
    {
        public CreateExerciseRequestValidator()
        {
            RuleFor(request => request.Model).NotNull();

            RuleFor(request => request.Model.Name).NotEmpty().WithMessage("The exercise has to have a name!")
                .MaximumLength(200)
                .WithMessage("Exercise name can be a maximum of 200 characters long!");
        }
    }
}
