using System;
using System.Threading.Tasks;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Data;

namespace BulkBuilder.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IExerciseRepository Exercise { get; }

        Task CommitAsync();
    }
}
