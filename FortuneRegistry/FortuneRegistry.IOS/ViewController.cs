using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using FortuneRegistry.IOS.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using UIKit;

namespace FortuneRegistry.IOS
{
    public partial class ViewController : UIViewController
    {
        private readonly CurrencyPickerModel _currencyPickerModel = new CurrencyPickerModel();
        private readonly CategoryPickerModel _categoryPickerModel = new CategoryPickerModel();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PickerCurrency.Model = _currencyPickerModel;
            PickerCategory.Model = _categoryPickerModel;


            //TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            //{

            //    // Convert the phone number with text to a number
            //    // using PhoneTranslator.cs
            //    translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);

            //    // Dismiss the keyboard if text field was tapped
            //    PhoneNumberText.ResignFirstResponder();

            //    if (translatedNumber == "")
            //    {
            //        CallButton.SetTitle("Call", UIControlState.Normal);
            //        CallButton.Enabled = false;
            //    }
            //    else
            //    {
            //        CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
            //        CallButton.Enabled = true;
            //    }
            //};

            //CallButton.TouchUpInside += (object sender, EventArgs e) => {
            //    var url = new NSUrl("tel:" + translatedNumber);

            //    // Use URL handler with tel: prefix to invoke Apple's Phone app,
            //    // otherwise show an alert dialog

            //    if (!UIApplication.SharedApplication.OpenUrl(url))
            //    {
            //        var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
            //        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            //        PresentViewController(alert, true, null);
            //    }
            //};
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnAdd_TouchUpInside(UIButton sender)
        {
            _categoryPickerModel.Names.Add("Test");
            PickerCategory.Model = _categoryPickerModel;

            Test(null);
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = {SheetsService.Scope.SpreadsheetsReadonly};
        static string ApplicationName = "Google Sheets API .NET Quickstart";

        static void Test(string[] args)
        {
            UserCredential credential;

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ViewController)).Assembly;
            Stream stream1 = assembly.GetManifestResourceStream("FortuneRegistry.IOS.Config.gcred.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream1))
            {
                text = reader.ReadToEnd();
            }



            var rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText(Path.Combine(rootFolder, "hello.txt"), "Hello!");

            var files = Directory.GetFiles(rootFolder);

            using (var stream =
                new FileStream("gcreds.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            String range = "Class Data!A2:E";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                Console.WriteLine("Name, Major");
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    Console.WriteLine("{0}, {1}", row[0], row[4]);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            Console.Read();
        }
    }
}