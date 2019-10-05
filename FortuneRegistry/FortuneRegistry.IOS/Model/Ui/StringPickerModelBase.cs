using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model.Ui
{
    public class StringPickerModelBase : UIPickerViewModel, IPickerModel
    {
        public List<string> Items { get; set; } = new List<string>();
        public string SelectedItem { get; private set; } = string.Empty;

        public event EventHandler<EventArgs> ValueChanged;

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Items.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return Items[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            SelectedItem = Items[(int)pickerView.SelectedRowInComponent(0)];

            var si = (int)row;
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }

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