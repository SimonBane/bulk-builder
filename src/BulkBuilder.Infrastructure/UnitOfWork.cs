using System;
using System.Threading.Tasks;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Users.Data;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Data;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;
        private DbContext _dbContext;

        public UnitOfWork(DbContext dbContext, IExerciseRepository exercise, IWorkoutRepository workout,
            IWorkoutExerciseRepository workoutExercise, IUserRepository user)
        {
            _dbContext = dbContext;
            Exercise = exercise;
            Workout = workout;
            WorkoutExercise = workoutExercise;
            User = user;
        }

        public IExerciseRepository Exercise { get; set; }
        public IWorkoutRepository Workout { get; }
        public IWorkoutExerciseRepository WorkoutExercise { get; }
        public IUserRepository User { get; }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (!disposing || _dbContext == null)
                    return;

                _dbContext.Dispose();
                _dbContext = null;
            }

            _isDisposed = true;
        }
    }
}