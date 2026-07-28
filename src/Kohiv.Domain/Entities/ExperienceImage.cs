namespace Kohiv.Domain.Entities
{
    public class ExperienceImage
    {
        private ExperienceImage()
        {
        }

        public ExperienceImage(string imageUrl, bool isCover = false, int displayOrder = 0)
        {
            SetImageUrl(imageUrl);
            IsCover = isCover;
            DisplayOrder = displayOrder;
        }

        public int Id { get; private set; }

        public int ExperienceId { get; private set; }

        public string ImageUrl { get; private set; } = string.Empty;

        public bool IsCover { get; private set; }

        public int DisplayOrder { get; private set; }

        public void SetImageUrl(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                throw new ArgumentException("Image URL is required.", nameof(imageUrl));
            }

            ImageUrl = imageUrl.Trim();
        }

        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }

        internal void MarkAsCover()
        {
            IsCover = true;
        }

        internal void ClearCover()
        {
            IsCover = false;
        }
    }
}
