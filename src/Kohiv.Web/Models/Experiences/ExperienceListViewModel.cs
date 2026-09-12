namespace Kohiv.Web.Models.Experiences
{
    public class ExperienceListViewModel
    {
        public IReadOnlyList<ExperienceListItemViewModel> Experiences { get; set; } = new List<ExperienceListItemViewModel>();
    }
}
