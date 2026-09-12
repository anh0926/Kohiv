using Kohiv.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kohiv.Web.Models.Experiences
{
    public class CreateExperienceViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public ExperienceStatus Status { get; set; } = ExperienceStatus.Wishlist;

        [MaxLength(300)]
        public string? Location { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        [Url]
        public string? SourceUrl { get; set; }

        public IReadOnlyList<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
