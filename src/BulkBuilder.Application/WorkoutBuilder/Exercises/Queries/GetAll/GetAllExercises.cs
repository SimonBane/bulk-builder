using System.Collections.Generic;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Queries.GetAll
{
    public class GetAllExercises : IRequest<IEnumerable<ExerciseDto>>
    {
    }
}
