using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using BulkBuilder.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class CreateExerciseHandler : BaseRequestHandler<CreateExercise, ExerciseDto>
    {
        private readonly IMemoryCache _memoryCache;
        public CreateExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
            : base(mapper, unitOfWork)
        {
            _memoryCache = memoryCache;
        }

        public override async Task<ExerciseDto> Handle(CreateExercise request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Exercise>(request.Model);

            await UnitOfWork.Exercise.InsertAsync(entity);
            await UnitOfWork.CommitAsync();
            
            _memoryCache.Remove(CacheKeys.GetAllExercises);

            return await UnitOfWork.Exercise.ProjectToAsync<ExerciseDto>(e => e.Id == entity.Id);
        }
    }
}
