using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FortuneRegistry.IOS.Model.Range;
using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model
{
    public class Registry
    {
        private readonly GoogleSheetsClient _googleSheetsClient;
        public Registry(GoogleSheetsClient googleSheetsClient)
        {
            _googleSheetsClient = googleSheetsClient;
        }

        public void SaveExpense(string amount, string currency, string category, string description)
        {
            var valuesArr = new List<string>
            {
                DateTime.UtcNow.Date.ToShortDateString(),
                amount,
                currency,
                CurrencyRates.Convert("USD", currency).ToString(CultureInfo.InvariantCulture)
            };

            // TODO: move to constant and then to settings.
            var last = _googleSheetsClient.GetFirstEmptyCell("Transactions!B4:B500");

            var firstPart = last;
            var secondPart = new GSheetRange(last.TableName, "G" + last.RangeStart.YNumber, null);

            _googleSheetsClient.WriteRows(firstPart.ToString(), valuesArr);
            valuesArr.Clear();

            valuesArr.Add(description);
            valuesArr.Add(category);

            _googleSheetsClient.WriteRows(secondPart.ToString(), valuesArr);
        }
    }
}