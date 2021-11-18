using System.Collections.Generic;
using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }
}
