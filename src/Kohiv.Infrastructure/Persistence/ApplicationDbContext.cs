using Kohiv.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kohiv.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Experience> Experiences => Set<Experience>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<ExperienceImage> ExperienceImages => Set<ExperienceImage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
