using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Shared.Models.Summary
{
    public class CategorySummary
    {
        public Plan Plan { get; set; } = Plan.Uninitialized;
        public IEnumerable<Transaction> Transactions { get; set; } = Enumerable.Empty<Transaction>();
        public TransactionType Type { get; set; }
        public Money Actual
        {
            get
            {
                var amount = Transactions.Aggregate(0m, (i, transaction) => i += transaction.Amount);

                return new Money(amount, new Currency("NON_NORMALIZED_CURRENCY"));
            }
        }
    }
}
