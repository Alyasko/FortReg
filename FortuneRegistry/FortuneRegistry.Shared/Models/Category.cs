using System;
using System.Collections.Generic;
using System.Linq;

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

        public string Name { get; set; } = String.Empty;
        public IEnumerable<Category> SubCategories { get; set; } = Enumerable.Empty<Category>();
        public int Id { get; set; }
    }
}
