using FortuneRegistry.Shared.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FortuneRegistry.Persistence
{
    public class TransactionsRepository : BaseRepository<Transaction>
    {
        protected override string CollectionName { get; set; } = "transactions";

        public async Task<IEnumerable<Transaction>> GetIncomesAsync(CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Type == TransactionType.Income, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> GetIncomesAsync(DateTime dateMonth, CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Date != null && (x.Type == TransactionType.Income && x.Date.Value.Year == dateMonth.Year && x.Date.Value.Month == dateMonth.Month), cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> GetExpensesAsync(CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Type == TransactionType.Expense, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> GetExpensesAsync(DateTime dateMonth, CancellationToken cancellationToken = default)
        {
            return await QueryAsync(x => x.Date != null && (x.Type == TransactionType.Expense && dateMonth.Year == x.Date.Value.Year && dateMonth.Month == x.Date.Value.Month), cancellationToken).ConfigureAwait(false);
        }
    }
}
