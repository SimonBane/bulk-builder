using BulkBuilder.Application.WorkoutBuilder.Exercises.Commands.Create;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Queries.Get;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Queries.GetAll;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises
{
    public static class ExerciseRequests
    {
        public static readonly GetAllExercises GetAll = new();
        public static GetExercise GetById(int id) => new() { Id = id };
        public static CreateExercise Create(ExerciseCreateDto model) => new() { Model = model };
    }
}
