using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace FortuneRegistry.IOS.Model
{
    public abstract class BaseController : UIViewController
    {
        private static bool _exRegistered = false;

        static BaseController()
        {

        }

        protected BaseController(IntPtr handle) : base(handle)
        {
            if (_exRegistered == false)
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, args) => {
                    System.Exception ex = (System.Exception)args.ExceptionObject;
                    ShowError(ex.Message);
                };
                _exRegistered = true;
            }
        }

        protected void ShowMessage(string text)
        {
            var alert = UIAlertController.Create("Information", text, UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        protected void ShowError(string text)
        {
            var alert = UIAlertController.Create("Error", text, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}