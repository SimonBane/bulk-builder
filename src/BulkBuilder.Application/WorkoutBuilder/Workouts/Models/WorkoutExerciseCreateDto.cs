namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutExerciseCreateDto
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int Order { get; set; }
    }
}