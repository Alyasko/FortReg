using System.IO;
using Android.Content.Res;
using FortuneRegistry.Android.Config;
using FortuneRegistry.Shared.Mobile;

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
            var asset = _assets.Open(Path.Combine("Config", "gcreds.json"));
            var all = _assets.List("Config");
            return asset;
        }

        public string GoogleSheetId => GSheets.SheetId;
    }
}