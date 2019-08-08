using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Persistence
{
    public class TransactionsRepository : BaseRepository<Transaction>
    {
        protected override string CollectionName { get; set; } = "transactions";

        public IEnumerable<Transaction> GetIncomes()
        {
            return Collection.Find(x => x.Type == TransactionType.Income);
        }

        public IEnumerable<Transaction> GetExpenses()
        {
            return Collection.Find(x => x.Type == TransactionType.Expense);
        }
    }
}
