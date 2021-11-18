using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Data;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Data;
using BulkBuilder.Domain.Entities;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class WorkoutExerciseRepository : BaseRepository<WorkoutExercise>, IWorkoutExerciseRepository
    {
        public WorkoutExerciseRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
