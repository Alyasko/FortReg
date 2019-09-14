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
            return Collection.Find(x => x.Created != null && x.Type == TransactionType.Expense && dateMonth.Month == x.Created.Value.Month && dateMonth.Year == x.Created.Value.Year);
        }

        public IEnumerable<Plan> GetIncomesPlan(DateTime dateMonth)
        {
            return Collection.Find(x => x.Created != null && x.Type == TransactionType.Income && dateMonth.Month == x.Created.Value.Month && dateMonth.Year == x.Created.Value.Year);
        }
    }
}
