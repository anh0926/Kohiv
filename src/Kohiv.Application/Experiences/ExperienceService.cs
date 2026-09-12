using Kohiv.Application.Common.Interfaces;
using Kohiv.Domain.Entities;
using Kohiv.Domain.Enums;

namespace Kohiv.Application.Experiences
{
    public class ExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ExperienceService(
            IExperienceRepository experienceRepository,
            ICategoryRepository categoryRepository)
        {
            _experienceRepository = experienceRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyList<Experience>> GetAllAsync()
        {
            return await _experienceRepository.GetAllAsync();
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _experienceRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(
            string userId,
            int categoryId,
            string title,
            ExperienceStatus status,
            string? description,
            string? location,
            string? sourceUrl)
        {
            var now = DateTime.UtcNow;

            var experience = new Experience(
                userId,
                categoryId,
                title,
                status,
                now);

            experience.UpdateDetails(
                categoryId,
                title,
                status,
                description,
                location,
                sourceUrl,
                now);

            await _experienceRepository.AddAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return experience.Id;
        }
    }
}
