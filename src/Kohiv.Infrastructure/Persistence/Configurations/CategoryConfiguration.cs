using Kohiv.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kohiv.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new { Id = 1, Name = "Hiking" },
            new { Id = 2, Name = "Cafe" },
            new { Id = 3, Name = "Restaurant" },
            new { Id = 4, Name = "Scenic Place" },
            new { Id = 5, Name = "Activity" });
    }
}
