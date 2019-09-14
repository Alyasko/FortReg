using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Debug = System.Diagnostics.Debug;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FortuneRegistry.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }



        public override bool OnOptionsItemSelected(IMenuItem item)   
        {  
            switch (item.ItemId)   
            {  
//                case Android.Resource.Id.Home:  
//                    drawerLayout.OpenDrawer(GravityCompat.Start);  
//                    return true;  
            }  
            return base.OnOptionsItemSelected(item);  
        }  

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}