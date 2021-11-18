using System.Collections.Generic;
using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Models
{
    public class WorkoutUpdateDto
    {
        public string Name { get; set; }
        public List<WorkoutExerciseUpdateDto> Exercises { get; set; }
    }
}