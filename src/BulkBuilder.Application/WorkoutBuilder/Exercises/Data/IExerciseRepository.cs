using BulkBuilder.Application.Abstractions;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Data
{
    public interface IExerciseRepository : IProjectionRepository<Exercise>
    {
    }
}
