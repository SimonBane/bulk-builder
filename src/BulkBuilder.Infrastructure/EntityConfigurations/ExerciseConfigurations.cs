using BulkBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkBuilder.Infrastructure.EntityConfigurations
{
    public class ExerciseConfigurations : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercise");

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
