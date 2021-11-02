using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Data;
using BulkBuilder.Domain.Entities;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class ExerciseRepository : ProjectionRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }
    }
}