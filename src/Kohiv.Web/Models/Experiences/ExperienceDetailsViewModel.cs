namespace Kohiv.Web.Models.Experiences
{
    public class ExperienceDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? SourceUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
