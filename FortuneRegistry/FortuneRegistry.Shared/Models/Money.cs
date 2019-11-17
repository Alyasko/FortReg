using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models
{
    public class Money : IBaseDbModel
    {
        public Money()
        {
            
        }
        public Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public Currency Currency { get; set; } = new Currency();
        public decimal Value { get; set; }
    }
}
