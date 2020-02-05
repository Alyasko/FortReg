using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Core.Transactions
{
    public class TransactionsService
    {
        public Task AddAsync(TransactionRequest transaction, CancellationToken cancellationToken = default)
        {
            if (transaction.Date == null)
                transaction.Date = DateTime.UtcNow;

            var db = new TransactionsRepository();
            //var bson = db.Add(transaction);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var db = new TransactionsRepository();
            return await db.QueryAllAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> GetIncomesAsync(CancellationToken cancellationToken = default)
        {
            var db = new TransactionsRepository();
            return await db.GetIncomesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> GetExpensesAsync(CancellationToken cancellationToken = default)
        {
            var db = new TransactionsRepository();
            return await db.GetExpensesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var db = new CurrenciesRepository();
            return await db.QueryAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
