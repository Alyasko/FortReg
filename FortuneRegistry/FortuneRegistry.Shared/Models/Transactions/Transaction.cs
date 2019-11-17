using System;

namespace FortuneRegistry.Shared.Models.Transactions
{
    public class Transaction : ITransaction
    {
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; } = new Currency();
        public string Description { get; set; } = String.Empty;
        public Category Category { get; set; } = new Category();
        public FamilyMember TargetMember { get; set; } = new FamilyMember();
        public FamilyMember Owner { get; set; } = new FamilyMember();
        public TransactionType Type { get; set; }
        public int Id { get; set; }
    }
}
