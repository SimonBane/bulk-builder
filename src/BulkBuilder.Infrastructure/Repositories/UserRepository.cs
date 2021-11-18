using System.Threading.Tasks;
using BulkBuilder.Application.Users.Data;
using BulkBuilder.Domain.Entities;
using BulkBuilder.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<bool> IsExistingUser(int id)
        {
            return await Entity.AsNoTracking().AnyAsync(u => u.Id == id);
        }
    }
}