using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneRegistry.Shared.Models
{
    public class Currency : IBaseDbModel
    {
        public Currency()
        {
            
        }

        public Currency(string code)
        {
            Code = code;
        }

        public string Code { get; set; } = String.Empty;
    }
}
