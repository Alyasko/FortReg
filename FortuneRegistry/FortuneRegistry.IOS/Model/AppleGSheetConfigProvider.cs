using System.IO;
using System.Reflection;
using FortuneRegistry.IOS.Config;
using FortuneRegistry.Shared.Mobile;

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