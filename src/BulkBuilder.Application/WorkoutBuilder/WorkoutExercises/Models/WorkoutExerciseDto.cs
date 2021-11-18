using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models
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
