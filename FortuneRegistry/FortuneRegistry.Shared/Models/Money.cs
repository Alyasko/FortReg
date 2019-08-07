using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models
{
    public class Money
    {
        public Currency Currency { get; set; }
        public decimal Value { get; set; }
    }
}
