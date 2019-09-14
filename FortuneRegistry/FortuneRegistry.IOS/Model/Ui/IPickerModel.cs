using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model.Ui
{
    public interface IPickerModel
    {
        List<string> Items { get; set; }
    }
}