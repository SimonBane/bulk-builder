using BulkBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkBuilder.Infrastructure
{
    public class BulkDbContext : DbContext
    {
        public BulkDbContext(DbContextOptions<BulkDbContext> options)
            : base(options)
        { }

        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BulkDbContext).Assembly);
        }
    }
}
