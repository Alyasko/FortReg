namespace FortuneRegistry.Shared.Models
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Category[] SubCategories { get; set; }
    }
}
