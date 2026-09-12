using Kohiv.Application.Common.Interfaces;
using Kohiv.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kohiv.Infrastructure.Persistence.Respositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
