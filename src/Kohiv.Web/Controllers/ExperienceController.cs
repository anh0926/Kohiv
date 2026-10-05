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

            var experienceItems = experiences.Select(e => new ExperienceListItemViewModel
            {
                Id = e.Id,
                Title = e.Title,
                CategoryName = e.Category?.Name ?? string.Empty,
                Status = e.Status.ToString(),
                CreatedAt = e.CreatedAt
            }).ToList();

            var viewModel = new ExperienceListViewModel
            {
                Experiences = experienceItems
            };

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var experience = await _experienceService.GetByIdAsync(id);

            if (experience is null)
            {
                return NotFound();
            }

            var viewModel = new EditExperienceViewModel
            {
                Id = experience.Id,
                Title = experience.Title,
                CategoryId = experience.CategoryId,
                Status = experience.Status,
                Description = experience.Description,
                Location = experience.Location,
                SourceUrl = experience.SourceUrl,
                Categories = await GetCategorySelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditExperienceViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                viewModel.Categories = await GetCategorySelectListAsync();
                return View(viewModel);
            }

            var updated = await _experienceService.UpdateAsync(
                viewModel.Id,
                viewModel.CategoryId,
                viewModel.Title,
                viewModel.Status,
                viewModel.Description,
                viewModel.Location,
                viewModel.SourceUrl);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id = viewModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _experienceService.GetByIdAsync(id);

            if (experience is null)
            {
                return NotFound();
            }

            var viewModel = new DeleteExperienceViewModel
            {
                Id = experience.Id,
                Title = experience.Title,
                CategoryName = experience.Category?.Name ?? string.Empty,
                Status = experience.Status.ToString()
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _experienceService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IReadOnlyList<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _experienceService.GetCategoriesAsync();

            var categoryItems = new List<SelectListItem>();

            foreach (var category in categories)
            {
                var item = new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                };
                categoryItems.Add(item);
            }

            return categoryItems;
        }        
    }
}
