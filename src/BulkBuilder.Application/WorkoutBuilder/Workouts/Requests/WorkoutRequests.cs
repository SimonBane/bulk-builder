using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class WorkoutRequests
    {
        public static GetAllWorkouts GetAllWorkouts(int userId) => new() { UserId = userId };
        
        public static GetWorkout GetWorkout(int userId, int workoutId) => new() { Id = workoutId, UserId = userId };

        public static CreateWorkout CreateWorkout(int userId, WorkoutCreateDto model) =>
            new() { UserId = userId, Model = model };

        public static UpdateWorkout UpdateWorkout(int userId, int workoutId, WorkoutUpdateDto model) =>
            new() { UserId = userId, WorkoutId = workoutId, Model = model };

        public static DeleteWorkout DeleteWorkout(int userId, int workoutId) =>
            new() { WorkoutId = workoutId, UserId = userId };
    }
}