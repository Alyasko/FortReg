using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _categoriesRepository.QueryAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
