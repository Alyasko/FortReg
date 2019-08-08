using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models
{
    public class Currency
    {
        public Currency(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
