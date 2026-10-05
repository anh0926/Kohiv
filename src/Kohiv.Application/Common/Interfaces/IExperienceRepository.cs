using Kohiv.Domain.Entities;

namespace Kohiv.Application.Common.Interfaces
{
   public interface IExperienceRepository
    {
        Task<IReadOnlyList<Experience>> GetAllAsync();

        Task<Experience?> GetByIdAsync(int id);

        Task AddAsync(Experience experience);

        void Remove(Experience experience);

        Task SaveChangesAsync();
    }
}
