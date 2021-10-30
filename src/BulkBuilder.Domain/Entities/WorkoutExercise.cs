namespace BulkBuilder.Domain.Entities
{
    public class WorkoutExercise : BaseEntity
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public double RestTimeInSeconds { get; set; }
        public int Order { get; set; }
    }
}
