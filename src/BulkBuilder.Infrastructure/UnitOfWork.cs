﻿using System;
using System.Threading.Tasks;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Data;

namespace BulkBuilder.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;
        private BulkDbContext _dbContext;

        public UnitOfWork(BulkDbContext dbContext, IExerciseRepository exercise)
        {
            _dbContext = dbContext;
            Exercise = exercise;
        }

        public IExerciseRepository Exercise { get; set; }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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