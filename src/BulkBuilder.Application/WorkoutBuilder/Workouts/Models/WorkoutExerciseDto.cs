namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutExerciseDto
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int Order { get; set; }
    }
}
