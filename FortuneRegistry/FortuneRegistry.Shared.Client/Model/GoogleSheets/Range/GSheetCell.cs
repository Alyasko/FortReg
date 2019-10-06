using System;
using System.Text.RegularExpressions;

namespace FortuneRegistry.Shared.Client.Model.GoogleSheets.Range
{
    public class GSheetCell
    {
        private GSheetCell()
        {
            
        }

        public static GSheetCell Parse(string cellAddress)
        {
            var r = new Regex("(?<x>\\w+?)(?<y>\\d+)");
            var m = r.Match(cellAddress);
            if (m.Success == false)
                throw new InvalidOperationException("Unable to parse cell address.");

            if(!int.TryParse(m.Groups["y"].Value, out var yN))
                throw new InvalidOperationException("Unable to parse cell address.");

            return new GSheetCell
            {
                XString = m.Groups["x"].Value, 
                YNumber = yN
            };
        }

        public string XString { get; private set; }
        public int YNumber { get; private set; }

        public override string ToString()
        {
            return $"{XString}{YNumber}";
        }
    }
}