using System;

namespace FortuneRegistry.XF.Models
{
    public class ExpenseListItem
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }

        public string Tag { get; set; }
    }
}
