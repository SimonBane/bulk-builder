using System.Threading.Tasks;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Data;
using BulkBuilder.Domain.Entities;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(DbContext dbContext)
            : base(dbContext)
        { }

        public override async Task<Workout> GetAsync(int id)
        {
            return await Entity
                .Include(w => w.Exercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
