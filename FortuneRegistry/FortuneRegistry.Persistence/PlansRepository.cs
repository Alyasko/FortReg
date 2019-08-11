using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Shared.Models.Summary;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Persistence
{
    public class PlansRepository : BaseRepository<Plan>
    {
        protected override string CollectionName { get; set; } = "category_summaries";

        public IEnumerable<Plan> GetExpensesPlan(DateTime dateMonth)
        {
            return Collection.Find(x => x.Created.Month == dateMonth.Month && x.Created.Year == dateMonth.Year && x.Type == TransactionType.Expense);
        }

        public IEnumerable<Plan> GetIncomesPlan(DateTime dateMonth)
        {
            return Collection.Find(x => x.Created.Month == dateMonth.Month && x.Created.Year == dateMonth.Year && x.Type == TransactionType.Income);
        }
    }
}
