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
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public FamilyMember TargetMember { get; set; }
        public int TargetMembeId { get; set; }

        [JsonIgnore]
        public FamilyMember Owner { get; set; }
        public int OwnerId { get; set; }

        public TransactionType Type { get; set; }

        public int Id { get; set; }
    }
}
