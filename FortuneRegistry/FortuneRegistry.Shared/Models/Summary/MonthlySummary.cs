using System.Collections.Generic;
using System.Linq;

namespace FortuneRegistry.Shared.Models.Summary
{
    public class MonthlySummary
    {
        public IEnumerable<CategorySummary> AllExpenses { get; set; } = Enumerable.Empty<CategorySummary>();
        public IEnumerable<CategorySummary> AllIncomes { get; set; } = Enumerable.Empty<CategorySummary>();
    }
}
