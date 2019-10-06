using System.IO;
using System.Reflection;
using Android.Content.Res;
using FortuneRegistry.Android.Config;
using FortuneRegistry.Shared.Client;

namespace FortuneRegistry.Android.Model
{
    class AndroidGSheetConfigProvider : IGSheetConfigProvider
    {
        private readonly AssetManager _assets;

        public AndroidGSheetConfigProvider(AssetManager assets)
        {
            _assets = assets;
        }

        public Stream ReadConfig()
        {
            return _assets.Open(Path.Combine("Config", "gcreds.json"));
        }

        public string GoogleSheetId => GSheets.SheetId;
    }
}