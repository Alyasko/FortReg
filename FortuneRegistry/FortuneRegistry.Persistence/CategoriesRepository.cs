﻿using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Persistence
{
    public class CategoriesRepository : BaseRepository<Category>
    {
        protected override string CollectionName { get; set; } = "category";
    }
}
