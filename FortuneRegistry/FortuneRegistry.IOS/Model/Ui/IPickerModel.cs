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
        void Add(string item);
        void Clear();
        void SelectFirst();
        string Get(int index);
        string SelectedItem { get; }
    }
}