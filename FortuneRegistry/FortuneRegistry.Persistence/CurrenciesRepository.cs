using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Persistence
{
    public class CurrenciesRepository : BaseRepository<Currency>
    {
        protected override string CollectionName { get; set; } = "currencies";
    }
}
