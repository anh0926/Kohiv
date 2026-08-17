using Kohiv.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kohiv.Infrastructure.Persistence.Configurations;

public class ExperienceImageConfiguration : IEntityTypeConfiguration<ExperienceImage>
{
    public void Configure(EntityTypeBuilder<ExperienceImage> builder)
    {
        builder.ToTable("ExperienceImages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExperienceId)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.IsCover)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();
    }
}
