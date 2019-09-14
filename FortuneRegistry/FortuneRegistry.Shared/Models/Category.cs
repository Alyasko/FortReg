namespace FortuneRegistry.Shared.Models
{
    public class Category : IBaseDbModel
    {
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Category[] SubCategories { get; set; }
        public int Id { get; set; }
    }
}
