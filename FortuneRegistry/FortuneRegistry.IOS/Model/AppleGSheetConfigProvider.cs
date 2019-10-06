using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FortuneRegistry.IOS.Config;
using FortuneRegistry.Shared.Client;
using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model
{
    class AppleGSheetConfigProvider : IGSheetConfigProvider
    {
        public Stream ReadConfig()
        {
            var assembly = typeof(ViewController).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream("FortuneRegistry.IOS.Config.gcreds.json");
        }

        public string GoogleSheetId => GSheets.SheetId;
    }
}