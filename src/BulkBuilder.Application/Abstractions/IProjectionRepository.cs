using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Persistence.Abstractions;

namespace BulkBuilder.Application.Abstractions
{
    public interface IProjectionRepository<T> : IRepository<T>
    {
        Task<List<TResult>> ProjectToAllAsync<TResult>(Expression<Func<T, bool>> filter = null);
        Task<TResult> ProjectToAsync<TResult>(Expression<Func<T, bool>> filter = null);
    }
}
