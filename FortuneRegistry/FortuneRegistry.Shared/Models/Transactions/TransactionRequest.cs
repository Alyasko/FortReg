using System;
using Newtonsoft.Json;

namespace FortuneRegistry.Shared.Models.Transactions
{
    [JsonObject]
    public class TransactionRequest : ITransaction
    {
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        public Currency Currency { get; set; } = new Currency();
        public int CurrencyId { get; set; }

        public string Description { get; set; } = String.Empty;

        [JsonIgnore]
        public Category Category { get; set; } = new Category();
        public int CategoryId { get; set; }

        [JsonIgnore]
        public FamilyMember TargetMember { get; set; } = new FamilyMember();
        public int TargetMembeId { get; set; }

        [JsonIgnore]
        public FamilyMember Owner { get; set; } = new FamilyMember();
        public int OwnerId { get; set; }

        public TransactionType Type { get; set; }

        public int Id { get; set; }
    }
}
