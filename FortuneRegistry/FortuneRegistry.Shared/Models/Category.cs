namespace FortuneRegistry.Shared.Models
{
    public class Category
    {
        public string Name { get; set; }
        public Category[] SubCategories { get; set; }
    }
}
