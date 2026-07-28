namespace Kohiv.Domain.Entities
{
    public class Category
    {
        private Category()
        {
        }

        public Category(string name)
        {
            SetName(name);
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public void Rename(string name)
        {
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name is required.", nameof(name));
            }

            Name = name.Trim();
        }
    }
}
