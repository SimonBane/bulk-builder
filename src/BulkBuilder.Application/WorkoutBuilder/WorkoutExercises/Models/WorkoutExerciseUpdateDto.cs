namespace BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models
{
    public class WorkoutExerciseUpdateDto
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int Order { get; set; }
    }
}