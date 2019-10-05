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
        private List<string> _items { get; set; } = new List<string>();
        public void Add(string item)
        {
            _items.Add(item);
            SelectedItem = item;
        }

        public void Clear()
        {
            _items.Clear();
            SelectedItem = string.Empty;
        }

        public void SelectFirst()
        {
            SelectedItem = _items.FirstOrDefault() ?? string.Empty;
        }

        public string Get(int index)
        {
            return _items[index];
        }

        public string SelectedItem { get; private set; } = string.Empty;

        public event EventHandler<EventArgs> ValueChanged;

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _items.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return _items[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            SelectedItem = _items[(int)pickerView.SelectedRowInComponent(0)];

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