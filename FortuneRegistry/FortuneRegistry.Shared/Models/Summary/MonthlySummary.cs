using System.Collections.Generic;

namespace FortuneRegistry.Shared.Models.Summary
{
    public class MonthlySummary
    {
        public IEnumerable<CategorySummary> AllExpenses { get; set; }
        public IEnumerable<CategorySummary> AllIncomes { get; set; }
    }
}
