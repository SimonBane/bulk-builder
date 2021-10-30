using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Abstractions
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
