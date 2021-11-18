using System.Collections.Generic;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutCreateDto
    {
        public string Name { get; set; }
        public List<WorkoutExerciseCreateDto> Exercises { get; set; }
    }
}