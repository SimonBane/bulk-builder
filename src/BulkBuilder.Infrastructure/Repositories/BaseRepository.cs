using System.Collections.Generic;
using System.Threading.Tasks;
using BulkBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly DbSet<T> Entity;

        public BaseRepository(DbContext dbContext)
        {
            Entity = dbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Entity.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            Entity.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            Entity.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
