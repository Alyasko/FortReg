using Foundation;
using System;
using FortuneRegistry.IOS.Model;
using UIKit;

namespace FortuneRegistry.IOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();


            var currencyPickerModel = new CurrencyPickerModel();
            PickerCurrency.Model = currencyPickerModel;

            var categoryPickerModel = new CategoryPickerModel();
            PickerCategory.Model = categoryPickerModel;


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

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnAdd_TouchUpInside(UIButton sender)
        {
            
        }
    }
}