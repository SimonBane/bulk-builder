using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using Microsoft.Extensions.Caching.Memory;
using static System.Net.HttpStatusCode;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class UpdateExerciseHandler : BaseRequestHandler<UpdateExercise, ExerciseDto>
    {
        private readonly IMemoryCache _memoryCache;

        public UpdateExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(mapper,
            unitOfWork)
        {
            _memoryCache = memoryCache;
        }

        public override async Task<ExerciseDto> Handle(UpdateExercise request, CancellationToken cancellationToken)
        {
            var exercise = await UnitOfWork.Exercise.GetAsync(request.Model.Id);
            if (exercise == null)
            {
                throw new HttpException(NotFound, "Exercise does not exist!");
            }

            Mapper.Map(request.Model, exercise);
            await UnitOfWork.CommitAsync();
            
            _memoryCache.Remove(CacheKeys.GetAllExercises);

            return Mapper.Map<ExerciseDto>(exercise);
        }
    }
}