using Kohiv.Application.Common.Interfaces;
using Kohiv.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kohiv.Infrastructure.Persistence.Respositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ExperienceRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Experience experience)
        {
            await _dbcontext.Experiences.AddAsync(experience);
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _dbcontext.Experiences
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Experience>> GetAllAsync()
        {
            return await _dbcontext.Experiences
                .Include(e => e.Category)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }
    }
}
