namespace Kohiv.Web.Models.Experiences
{
    public class ExperienceListItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
