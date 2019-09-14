using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FortuneRegistry.IOS.Config;
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
        public GoogleSheetsClient()
        {
            
        }

        private SheetsService CreateService()
        {
            UserCredential credential;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ViewController)).Assembly;

            GoogleCredential cr;
            using (var rStream = assembly.GetManifestResourceStream("FortuneRegistry.IOS.Config.gcred.json"))
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
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "FortReg";

        public IList<IList<Object>> ReadCells(string range)
        {
            var service = CreateService();

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(GSheets.SheetId, range);

            var response = request.Execute();

            return response.Values;
        }
    }
}