using System.Collections.Generic;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }
}
