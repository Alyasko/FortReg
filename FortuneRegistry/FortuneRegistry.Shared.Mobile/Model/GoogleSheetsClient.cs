using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FortuneRegistry.Shared.Mobile.Model.GoogleSheets.Range;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace FortuneRegistry.Shared.Mobile.Model
{
    public class GoogleSheetsClient
    {
        private SheetsService Service { get; }

        private readonly IGSheetConfigProvider _gSheetConfig;

        public GoogleSheetsClient(IGSheetConfigProvider gSheetConfig)
        {
            _gSheetConfig = gSheetConfig;

            Service = CreateService();
        }

        private SheetsService CreateService()
        {
            UserCredential credential;

            GoogleCredential cr;
            using (var rStream = _gSheetConfig.ReadConfig())
            {
                var reader = new StreamReader(rStream);
                var json = reader.ReadToEnd();
                cr = GoogleCredential.FromStream(rStream).CreateScoped(Scopes);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cr,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "FortReg";

        public IList<IList<object>> ReadCells2D(string range)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = Service.Spreadsheets.Values.Get(_gSheetConfig.GoogleSheetId, range);

            var response = request.Execute();

            return response.Values;
        }

        public IList<string> ReadCells1D(string range)
        {
            var v = ReadCells2D(range);
            if (v == null || v.Count == 0)
            {
                throw new InvalidOperationException("No cells from Google Sheet returned.");
            }

            return v.Select(x => x.Select(z => z.ToString()).ElementAt(0)).ToList();
        }

        public GSheetRange GetFirstEmptyCell(string range)
        {
            var r = GSheetRange.Parse(range);
            var all = ReadCells2D(range);

            var lastNumber = r.RangeStart.YNumber + all.Count;

            return new GSheetRange(r.TableName, $"{r.RangeStart.XString}{lastNumber}", null);
        }

        public UpdateValuesResponse WriteRows(string rangeOffset, IEnumerable<string> data)
        {
            return Write(rangeOffset, data, "ROWS");
        }

        public UpdateValuesResponse WriteColumns(string rangeOffset, IEnumerable<string> data)
        {
            return Write(rangeOffset, data, "COLUMNS");
        }

        private UpdateValuesResponse Write(string rangeOffset, IEnumerable<string> data, string majorDimension)
        {
            ValueRange valueRange = new ValueRange
            {
                MajorDimension = majorDimension, //"ROWS";//COLUMNS
                Values = new List<IList<object>>
                {
                    data.Cast<object>().ToList()
                }
            };

            var update = Service.Spreadsheets.Values.Update(valueRange, _gSheetConfig.GoogleSheetId, rangeOffset);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

            return update.Execute();
        }
    }
}