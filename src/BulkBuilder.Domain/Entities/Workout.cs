using System.Collections.Generic;

namespace BulkBuilder.Domain.Entities
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; }
        public List<WorkoutExercise> Exercises { get; set; }
    }
}
