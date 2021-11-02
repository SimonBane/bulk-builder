using BulkBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkBuilder.Infrastructure.EntityConfigurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workout");

            builder.Property(w => w.Name).HasMaxLength(200).IsRequired();

            builder.HasMany(w => w.Exercises)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
