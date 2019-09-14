using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Core.Transactions
{
    public class TransactionsService
    {
        public void Add(TransactionRequest transaction)
        {
            if(transaction.Date == null)
                transaction.Date = DateTime.UtcNow;

            using var db = new TransactionsRepository();
            var bson = db.Add(transaction);
        }

        public IEnumerable<Transaction> GetAll()
        {
            using var db = new TransactionsRepository();
            return db.GetAll();
        }

        public IEnumerable<Transaction> GetIncomes()
        {
            using var db = new TransactionsRepository();
            return db.GetIncomes();
        }

        public IEnumerable<Transaction> GetExpenses()
        {
            using var db = new TransactionsRepository();
            return db.GetExpenses();
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            using var db = new CurrenciesRepository();
            return db.GetAll();
        }
    }
}
