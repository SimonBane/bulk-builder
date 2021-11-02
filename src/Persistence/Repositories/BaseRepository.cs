using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistence.Repositories
{
    public abstract class BaseRepository<T>
    {
        private readonly IConfiguration _configuration;
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection() =>
            new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<List<T>> GetAllAsync()
        {
            using var connection = CreateConnection();
            connection.Open();

            var result = await connection.GetListAsync<T>();
            return result.ToList();
        }

        public async Task<T> GetAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();

            return await connection.GetAsync<T>(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            using var connection = CreateConnection();
            connection.Open();

            return await connection.InsertAsync(entity) ?? 0;
        }

        public async Task UpdateAsync(T entity)
        {
            using var connection = CreateConnection();
            connection.Open();

            await connection.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();

            await connection.DeleteAsync<T>(id);
        }
    }
}
