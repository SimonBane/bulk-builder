using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class ProjectionRepository<T> : BaseRepository<T>, IProjectionRepository<T>
        where T : BaseEntity
    {
        private readonly IMapper _mapper;

        public ProjectionRepository(DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<TResult>> ProjectToAllAsync<TResult>(Expression<Func<T, bool>> filter = null)
        {
            return await Project<TResult>(filter).ToListAsync();
        }

        public async Task<TResult> ProjectToAsync<TResult>(Expression<Func<T, bool>> filter = null)
        {
            return await Project<TResult>().FirstOrDefaultAsync();
        }

        private IQueryable<TResult> Project<TResult>(Expression<Func<T, bool>> filter = null)
        {
            var query = Entity.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query.ProjectTo<TResult>(_mapper.ConfigurationProvider);
        }
    }
}
