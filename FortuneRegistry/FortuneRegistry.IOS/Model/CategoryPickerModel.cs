using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model
{
    class CategoryPickerModel : UIPickerViewModel
    {
        public string[] names = new string[]
        {
            "Транспорт",
            "Бытовые",
            "Личные"
        };

        //private UILabel personLabel;

        public CategoryPickerModel()
        {
            //this.personLabel = personLabel;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return names.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return names[row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            //personLabel.Text =
            //    $"This person is: {names[pickerView.SelectedRowInComponent(0)]},\n they are number {pickerView.SelectedRowInComponent(1)}";
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            if (component == 0)
                return 240f;
            else
                return 40f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}