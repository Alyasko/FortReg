using FortuneRegistry.Shared.Models.Summary;
using FortuneRegistry.Shared.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FortuneRegistry.Persistence
{
    public class PlansRepository : BaseRepository<Plan>
    {
        protected override string CollectionName { get; set; } = "category_summaries";

        public async Task<IEnumerable<Plan>> GetExpensesPlanAsync(DateTime dateMonth, CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Created != null && x.Type == TransactionType.Expense && dateMonth.Month == x.Created.Value.Month && dateMonth.Year == x.Created.Value.Year, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Plan>> GetIncomesPlanAsync(DateTime dateMonth, CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Created != null && x.Type == TransactionType.Income && dateMonth.Month == x.Created.Value.Month && dateMonth.Year == x.Created.Value.Year, cancellationToken).ConfigureAwait(false);
        }
    }
}
