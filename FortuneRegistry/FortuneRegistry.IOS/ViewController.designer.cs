// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FortuneRegistry.IOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnAdd { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblAmountNormalized { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblConversion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblTotalAmount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView PickerCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView PickerCurrency { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TbAmount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TbDescription { get; set; }

        [Action ("BtnAdd_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAdd_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnAdd != null) {
                BtnAdd.Dispose ();
                BtnAdd = null;
            }

            if (LblAmountNormalized != null) {
                LblAmountNormalized.Dispose ();
                LblAmountNormalized = null;
            }

            if (LblConversion != null) {
                LblConversion.Dispose ();
                LblConversion = null;
            }

            if (LblDescription != null) {
                LblDescription.Dispose ();
                LblDescription = null;
            }

            if (LblTotalAmount != null) {
                LblTotalAmount.Dispose ();
                LblTotalAmount = null;
            }

            if (PickerCategory != null) {
                PickerCategory.Dispose ();
                PickerCategory = null;
            }

            if (PickerCurrency != null) {
                PickerCurrency.Dispose ();
                PickerCurrency = null;
            }

            if (TbAmount != null) {
                TbAmount.Dispose ();
                TbAmount = null;
            }

            if (TbDescription != null) {
                TbDescription.Dispose ();
                TbDescription = null;
            }
        }
    }
}