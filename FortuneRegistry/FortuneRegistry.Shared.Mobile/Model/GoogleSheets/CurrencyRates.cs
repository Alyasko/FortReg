using System;

namespace FortuneRegistry.Shared.Mobile.Model.GoogleSheets
{
    public class CurrencyRates
    {
        public static decimal Convert(string baseAsset, string quoteAsset)
        {
            var all = baseAsset + quoteAsset;
            switch (all)
            {
                case "USDUAH":
                    return 25;
                    break;
                case "USDRUR":
                    return 65;
                    break;
                case "USDEUR":
                    return 0.9m;
                    break;
                case "USDUSD":
                    return 1.0m;
                default:
                    throw new IndexOutOfRangeException($"Unable to convert pair {all}");
            }
        }
    }
}