using Kohiv.Domain.Entities;

namespace Kohiv.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetAllAsync();
    }
}
