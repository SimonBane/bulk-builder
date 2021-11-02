using BulkBuilder.Domain.Entities;
using Persistence.Abstractions;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Data
{
    public interface IWorkoutExerciseRepository : IRepository<WorkoutExercise>
    {
    }
}
