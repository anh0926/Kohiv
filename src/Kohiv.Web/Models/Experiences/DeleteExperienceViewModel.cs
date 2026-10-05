namespace Kohiv.Web.Models.Experiences
{
    public class DeleteExperienceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
