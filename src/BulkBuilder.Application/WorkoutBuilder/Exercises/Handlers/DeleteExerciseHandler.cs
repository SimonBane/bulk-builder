using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Requests;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BulkBuilder.Application.WorkoutBuilder.Exercises.Handlers
{
    public class DeleteExerciseHandler : BaseRequestHandler<DeleteExercise, Unit>
    {
        private readonly IMemoryCache _memoryCache;
        
        public DeleteExerciseHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
            : base(mapper, unitOfWork)
        {
            _memoryCache = memoryCache;
        }

        public override async Task<Unit> Handle(DeleteExercise request, CancellationToken cancellationToken)
        {
            var entity = await UnitOfWork.Exercise.GetAsync(request.Id);
            if (entity != null)
            {
                await UnitOfWork.Exercise.DeleteAsync(entity);
                await UnitOfWork.CommitAsync();
                
                _memoryCache.Remove(CacheKeys.GetAllExercises);
            }

            return Unit.Value;
        }
    }
}
