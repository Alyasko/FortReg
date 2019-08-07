using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models.Summary
{
    public class CategorySummary
    {
        public Category Category { get; set; }
        public Money PlannedAmount { get; set; }
    }
}
