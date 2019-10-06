using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FortuneRegistry.Shared.Client
{
    public interface IGSheetConfigProvider
    {
        Stream ReadConfig();

        string GoogleSheetId { get; }
    }
}
