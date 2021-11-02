using BulkBuilder.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Persistence.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>
    {
        public ExerciseRepository(IConfiguration configuration) : base(configuration)
        { }
    }
}
