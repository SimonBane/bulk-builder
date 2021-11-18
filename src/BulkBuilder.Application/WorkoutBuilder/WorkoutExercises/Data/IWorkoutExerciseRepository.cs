using BulkBuilder.Domain.Entities;
using Persistence.Abstractions;

namespace BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Data
{
    public interface IWorkoutExerciseRepository : IRepository<WorkoutExercise>
    {
    }
}
