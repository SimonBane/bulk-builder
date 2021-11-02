namespace BulkBuilder.Domain.Entities
{
    public class WorkoutExercise : BaseEntity
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int Order { get; set; }
    }
}
