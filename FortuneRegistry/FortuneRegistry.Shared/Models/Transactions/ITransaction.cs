using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models.Transactions
{
    public interface ITransaction : IBaseDbModel
    {
        DateTime? Date { get; set; }
        decimal Amount { get; set; }
        Currency Currency { get; set; }
        string Description { get; set; }
        Category Category { get; set; }
        FamilyMember TargetMember { get; set; }
        FamilyMember Owner { get; set; }
        TransactionType Type { get; set; }
    }
}
