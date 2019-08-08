using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Core.Transactions
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesService(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }
    }
}
