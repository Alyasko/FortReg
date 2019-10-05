using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using FortuneRegistry.IOS.Model;
using FortuneRegistry.IOS.Model.Ui;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using UIKit;

namespace FortuneRegistry.IOS
{
    public partial class ViewController : BaseController
    {
        private readonly StringPickerModelBase _currencyPickerModel = new StringPickerModelBase();
        private readonly StringPickerModelBase _categoryPickerModel = new StringPickerModelBase();

        private readonly GoogleSheetsClient _googleSheetsClient = new GoogleSheetsClient();
        private readonly Registry _registry;

        public ViewController(IntPtr handle) : base(handle)
        {
            _registry = new Registry(_googleSheetsClient);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TbDescription.ShouldReturn += TbShouldReturn;
            TbAmount.ShouldReturn += TbShouldReturn;
            TbDescription.EditingChanged += TbDescriptionOnEditingChanged;
            TbAmount.EditingChanged += TbAmountOnEditingChanged;

            _currencyPickerModel.ValueChanged += CurrencyPickerModelOnValueChanged;
            _categoryPickerModel.ValueChanged += CategoryPickerModelOnValueChanged;

            FillCategories();
            FillCurrencies();

            UpdateSummary();

            //TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            //{

            //    // Convert the phone number with text to a number
            //    // using PhoneTranslator.cs
            //    translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);

            //    // Dismiss the keyboard if text field was tapped
            //    PhoneNumberText.ResignFirstResponder();

            //    if (translatedNumber == "")
            //    {
            //        CallButton.SetTitle("Call", UIControlState.Normal);
            //        CallButton.Enabled = false;
            //    }
            //    else
            //    {
            //        CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
            //        CallButton.Enabled = true;
            //    }
            //};

            //CallButton.TouchUpInside += (object sender, EventArgs e) => {
            //    var url = new NSUrl("tel:" + translatedNumber);

            //    // Use URL handler with tel: prefix to invoke Apple's Phone app,
            //    // otherwise show an alert dialog

            //    if (!UIApplication.SharedApplication.OpenUrl(url))
            //    {
            //        var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
            //        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            //        PresentViewController(alert, true, null);
            //    }
            //};
        }

        private void CategoryPickerModelOnValueChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void TbDescriptionOnEditingChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void CurrencyPickerModelOnValueChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void TbAmountOnEditingChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            var amount = 0m;
            if(decimal.TryParse(TbAmount.Text, out var a))
                amount = a;

            LblTotalAmount.Text = $"{(string.IsNullOrWhiteSpace(TbAmount.Text) ? "0" : TbAmount.Text)} {_currencyPickerModel.SelectedItem}";
            LblAmountNormalized.Text = $" = {amount / CurrencyRates.Convert("USD", _currencyPickerModel.SelectedItem):F2} USD";
            LblConversion.Text = $"1 USD = {CurrencyRates.Convert("USD", _currencyPickerModel.SelectedItem)} {_currencyPickerModel.SelectedItem}";
            LblDescription.Text = TbDescription.Text;
        }

        private string[][] ReadCellRange(string range)
        {
            var v = _googleSheetsClient.ReadCells(range);
            if (v == null || v.Count == 0)
            {
                throw new InvalidOperationException("No cells from datasheet returned");
            }

            return v.Select(x => x.Select(z => z.ToString()).ToArray()).ToArray();
        }

        private void FillCategories()
        {
            _categoryPickerModel.Clear();

            var cats = ReadCellRange("Summary!B28:B50");

            foreach (var i in cats)
            {
                _categoryPickerModel.Add(i[0].ToString());
            }

            PickerCategory.Model = _categoryPickerModel;

        }

        private void FillCurrencies()
        {
            _currencyPickerModel.Clear();

            var cuurs = ReadCellRange("Summary!N9:N12");

            foreach (var i in cuurs)
            {
                _currencyPickerModel.Add(i[0].ToString());
            }

            PickerCurrency.Model = _currencyPickerModel;
            _currencyPickerModel.SelectFirst();
        }

        private bool TbShouldReturn(UITextField textfield)
        {
            textfield.ResignFirstResponder();

            return true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnAdd_TouchUpInside(UIButton sender)
        {
            if(!ValidateInput())
                return;

            _registry.SaveExpense(TbAmount.Text, _currencyPickerModel.SelectedItem, _categoryPickerModel.SelectedItem, TbDescription.Text);

            ShowMessage("Record added.");
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TbAmount.Text))
            {
                ShowMessage("Please enter transaction amount.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TbDescription.Text))
            {
                ShowMessage("Please enter transaction description.");
                return false;
            }

            return true;
        }
    }
}