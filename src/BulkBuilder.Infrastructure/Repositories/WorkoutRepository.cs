using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Data;
using BulkBuilder.Domain.Entities;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class WorkoutRepository : ProjectionRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Workout> GetUserWorkout(int userId, int workoutId)
        {
            return await Entity
                .Include(w => w.User)
                .Include(w => w.Exercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == workoutId && w.UserId == userId);
        }
    }
}