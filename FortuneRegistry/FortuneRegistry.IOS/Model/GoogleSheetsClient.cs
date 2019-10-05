using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FortuneRegistry.IOS.Config;
using FortuneRegistry.IOS.Model.Range;
using Foundation;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UIKit;

namespace FortuneRegistry.IOS.Model
{
    public class GoogleSheetsClient
    {
        private SheetsService _service;
        private SheetsService Service => _service ?? (_service = CreateService());

        public GoogleSheetsClient()
        {
            
        }

        private SheetsService CreateService()
        {
            UserCredential credential;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ViewController)).Assembly;

            GoogleCredential cr;
            using (var rStream = assembly.GetManifestResourceStream("FortuneRegistry.IOS.Config.gcreds.json"))
            {
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

        public IList<IList<object>> ReadCells(string range)
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = Service.Spreadsheets.Values.Get(GSheets.SheetId, range);

            var response = request.Execute();

            return response.Values;
        }

        public GSheetRange GetFirstEmptyCell(string range)
        {
            var r = GSheetRange.Parse(range);
            var all = ReadCells(range);

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

            var update = Service.Spreadsheets.Values.Update(valueRange, GSheets.SheetId, rangeOffset);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            return update.Execute();
        }

        public void Test()
        {
            ReadCells("Transactions!B1:B100");
        }
    }
}