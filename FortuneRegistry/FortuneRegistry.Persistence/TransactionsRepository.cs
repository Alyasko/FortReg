using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Transaction> GetIncomes(DateTime dateMonth)
        {
            return Collection.Find(x => x.Date != null && (x.Type == TransactionType.Income && x.Date.Value.Year == dateMonth.Year && x.Date.Value.Month == dateMonth.Month));
        }

        public IEnumerable<Transaction> GetExpenses()
        {
            return Collection.Find(x => x.Type == TransactionType.Expense);
        }

        public IEnumerable<Transaction> GetExpenses(DateTime dateMonth)
        {
            return Collection.Find(x => x.Date != null && (x.Type == TransactionType.Expense && dateMonth.Year == x.Date.Value.Year && dateMonth.Month == x.Date.Value.Month));
        }
    }
}
