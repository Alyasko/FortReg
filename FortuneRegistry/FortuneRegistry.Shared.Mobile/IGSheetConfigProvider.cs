using System.IO;

namespace FortuneRegistry.Shared.Mobile
{
    public interface IGSheetConfigProvider
    {
        Stream ReadConfig();

        string GoogleSheetId { get; }
    }
}
