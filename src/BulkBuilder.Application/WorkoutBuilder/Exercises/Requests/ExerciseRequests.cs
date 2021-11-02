using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Requests
{
    public static class ExerciseRequests
    {
        public static readonly GetAllExercises GetAllExercises = new();
        public static GetExercise GetExercise(int id) => new() { Id = id };
        public static CreateExercise CreateExercise(ExerciseCreateDto model) => new() { Model = model };
        public static UpdateExercise UpdateExercise(ExerciseUpdateDto model) => new() { Model = model };
        public static DeleteExercise DeleteExercise(int id) => new() { Id = id };
    }
}
