using System.Threading.Tasks;
using BulkBuilder.Domain.Entities;
using Persistence.Abstractions;

namespace BulkBuilder.Application.Users.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> IsExistingUser(int id);
    }
}