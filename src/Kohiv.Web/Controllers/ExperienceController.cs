using Kohiv.Application.Experiences;
using Kohiv.Web.Models.Experiences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kohiv.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private const string TemporaryUserId = "local-dev-user";

        private readonly ExperienceService _experienceService;

        public ExperienceController(ExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<IActionResult> Index()
        {
            var experiences = await _experienceService.GetAllAsync();

            var viewModel = experiences
                .Select(x => new ExperienceListItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryName = x.Category?.Name ?? string.Empty,
                    Status = x.Status.ToString(),
                    CreatedAt = x.CreatedAt
                })
                .ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var experience = await _experienceService.GetByIdAsync(id);

            if (experience is null)
            {
                return NotFound();
            }

            var viewModel = new ExperienceDetailsViewModel
            {
                Id = experience.Id,
                Title = experience.Title,
                Description = experience.Description,
                Location = experience.Location,
                CategoryName = experience.Category?.Name ?? string.Empty,
                Status = experience.Status.ToString(),
                SourceUrl = experience.SourceUrl,
                CreatedAt = experience.CreatedAt,
                UpdatedAt = experience.UpdatedAt
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateExperienceViewModel
            {
                Categories = await GetCategorySelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExperienceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await GetCategorySelectListAsync();
                return View(viewModel);
            }

            var experienceId = await _experienceService.CreateAsync(
                TemporaryUserId,
                viewModel.CategoryId,
                viewModel.Title,
                viewModel.Status,
                viewModel.Description,
                viewModel.Location,
                viewModel.SourceUrl);

            return RedirectToAction(nameof(Details), new { id = experienceId });
        }

        private async Task<IReadOnlyList<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _experienceService.GetCategoriesAsync();

            return categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
        }
    }
}
