﻿using System;

namespace FortuneRegistry.Shared.Models.Transactions
{
    public class Transaction : ITransaction
    {
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public FamilyMember TargetMember { get; set; }
        public FamilyMember Owner { get; set; }
        public TransactionType Type { get; set; }
        public int Id { get; set; }
    }
}
