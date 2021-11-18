using System.Threading.Tasks;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Domain.Entities;
using Persistence.Abstractions;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Data
{
    public interface IWorkoutRepository : IProjectionRepository<Workout>
    {
        Task<Workout> GetUserWorkout(int userId, int workoutId);
    }
}
