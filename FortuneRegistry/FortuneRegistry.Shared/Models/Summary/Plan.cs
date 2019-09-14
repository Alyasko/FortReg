using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Shared.Models.Summary
{
    public class Plan : IBaseDbModel
    {
        public Plan()
        {
            
        }
        public Category Category { get; set; } = new Category("Not specified category");
        public DateTime? Created { get; set; }
        public Money PlannedAmount { get; set; } = new Money(0, new Currency("###"));
        public TransactionType Type { get; set; }

        public static Plan Uninitialized = new Plan();
    }
}
