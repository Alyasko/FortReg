using System;
using System.Text;

namespace FortuneRegistry.Shared.Client.Model.GoogleSheets.Range
{
    public class GSheetRange
    {
        private GSheetRange() { }

        public GSheetRange(string tableName, string start, string end)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
                TableName = tableName;

            if (!string.IsNullOrWhiteSpace(start))
                RangeStart = GSheetCell.Parse(start);

            if (!string.IsNullOrWhiteSpace(end))
                RangeEnd = GSheetCell.Parse(end);
        }

        public static GSheetRange Parse(string range)
        {
            var hasTableName = range.Contains("!");
            var hasRange = range.Contains(":");

            var parts = range.Split(new string[] {"!", ":"}, StringSplitOptions.RemoveEmptyEntries);

            var r = new GSheetRange();

            if (parts.Length == 3)
            {
                r.TableName = parts[0];
                r.RangeStart = GSheetCell.Parse(parts[1]);
                r.RangeEnd = GSheetCell.Parse(parts[2]);
            }
            else if (parts.Length == 2)
            {
                if (hasTableName)
                {
                    r.TableName = parts[0];
                    r.RangeStart = GSheetCell.Parse(parts[1]);
                }
                else
                {
                    if (hasRange)
                    {
                        r.RangeStart = GSheetCell.Parse(parts[0]);
                        r.RangeEnd = GSheetCell.Parse(parts[1]);
                    }
                    else
                    {
                        r.RangeStart = GSheetCell.Parse(parts[0]);
                    }
                }
            }
            else if (parts.Length == 1)
            {
                r.RangeStart = GSheetCell.Parse(parts[0]);
            }
            else
            {
                throw new InvalidOperationException($"Invalid range specified '{range}'.");
            }

            return r;
        }

        public string TableName { get; private set; }
        public GSheetCell RangeStart { get; private set; }
        public GSheetCell RangeEnd { get; private set; }

        public bool IsSingleCell => RangeEnd == null;
        public bool HasTableName => !string.IsNullOrWhiteSpace(TableName);

        public override string ToString()
        {
            var r = new StringBuilder();

            if (HasTableName)
                r.Append(TableName + "!");

            r.Append(RangeStart);

            if (!IsSingleCell)
                r.Append(":" + RangeEnd);

            return r.ToString();
        }
    }
}