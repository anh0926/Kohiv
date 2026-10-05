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
            var createdAt = DateTime.UtcNow;

            var experience = new Experience(
                userId,
                categoryId,
                title,
                status,
                createdAt,
                description,
                location,
                sourceUrl);

            await _experienceRepository.AddAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return experience.Id;
        }

        public async Task<bool> UpdateAsync(
            int id,
            int categoryId,
            string title,
            ExperienceStatus status,
            string? description,
            string? location,
            string? sourceUrl)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);

            if (experience is null)
            {
                return false;
            }

            experience.UpdateDetails(
                categoryId,
                title,
                status,
                description,
                location,
                sourceUrl,
                DateTime.UtcNow);

            await _experienceRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);

            if (experience is null)
            {
                return false;
            }

            _experienceRepository.Remove(experience);
            await _experienceRepository.SaveChangesAsync();

            return true;
        }
    }
}
