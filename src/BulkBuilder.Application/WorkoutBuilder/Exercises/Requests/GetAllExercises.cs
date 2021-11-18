using System.Collections.Generic;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Requests
{
    public class GetAllExercises : ICacheableRequest<IEnumerable<ExerciseDto>>
    {
        public string Key => CacheKeys.GetAllExercises;
    }
}
