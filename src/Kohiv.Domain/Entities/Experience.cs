using Kohiv.Domain.Enums;

namespace Kohiv.Domain.Entities
{
    public class Experience
    {
        private readonly List<ExperienceImage> _images = new();

        private Experience()
        {
        }

        public Experience(
            string userId,
            int categoryId,
            string title,
            ExperienceStatus status,
            DateTime createdAt)
        {
            SetOwner(userId);
            SetCategory(categoryId);
            SetTitle(title);
            ChangeStatus(status);

            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public int Id { get; private set; }

        public string UserId { get; private set; } = string.Empty;

        public int CategoryId { get; private set; }

        public Category? Category { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string? Description { get; private set; }

        public string? Location { get; private set; }

        public ExperienceStatus Status { get; private set; }

        public string? SourceUrl { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public IReadOnlyCollection<ExperienceImage> Images => _images.AsReadOnly();

        public void UpdateDetails(
            int categoryId,
            string title,
            ExperienceStatus status,
            string? description,
            string? location,
            string? sourceUrl,
            DateTime updatedAt)
        {
            SetCategory(categoryId);
            SetTitle(title);
            ChangeStatus(status);

            Description = NormalizeOptionalText(description);
            Location = NormalizeOptionalText(location);
            SourceUrl = NormalizeOptionalText(sourceUrl);
            UpdatedAt = updatedAt;
        }

        public void MarkAsCompleted(DateTime updatedAt)
        {
            ChangeStatus(ExperienceStatus.Completed);
            UpdatedAt = updatedAt;
        }

        public void AddImage(ExperienceImage image, DateTime updatedAt)
        {
            ArgumentNullException.ThrowIfNull(image);

            if (image.IsCover)
            {
                ClearCoverImages();
            }

            _images.Add(image);
            UpdatedAt = updatedAt;
        }

        public void SetCoverImage(int imageId, DateTime updatedAt)
        {
            var image = _images.FirstOrDefault(x => x.Id == imageId);

            if (image is null)
            {
                throw new InvalidOperationException("Image does not belong to this experience.");
            }

            ClearCoverImages();
            image.MarkAsCover();
            UpdatedAt = updatedAt;
        }

        public void RemoveImage(int imageId, DateTime updatedAt)
        {
            var image = _images.FirstOrDefault(x => x.Id == imageId);

            if (image is null)
            {
                return;
            }

            _images.Remove(image);
            UpdatedAt = updatedAt;
        }

        public void ChangeStatus(ExperienceStatus status)
        {
            if (!Enum.IsDefined(status))
            {
                throw new ArgumentOutOfRangeException(nameof(status), status, "Experience status is invalid.");
            }

            Status = status;
        }

        private void SetOwner(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User id is required.", nameof(userId));
            }

            UserId = userId.Trim();
        }

        private void SetCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(categoryId), "Category id must be greater than zero.");
            }

            CategoryId = categoryId;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Experience title is required.", nameof(title));
            }

            Title = title.Trim();
        }

        private void ClearCoverImages()
        {
            foreach (var image in _images)
            {
                image.ClearCover();
            }
        }

        private static string? NormalizeOptionalText(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}
