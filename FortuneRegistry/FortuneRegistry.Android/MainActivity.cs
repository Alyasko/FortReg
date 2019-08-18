using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;

namespace FortuneRegistry.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _btnIncrease;
        private TextView _tvCounter;

        private int _counter = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _btnIncrease = FindViewById<Button>(Resource.Id.btnIncrease);
            _tvCounter = FindViewById<TextView>(Resource.Id.tvCounter);
            
            _tvCounter.SetOnClickListener();
        }

        private void TvCounterOnClick(object sender, EventArgs e)
        {
            _counter++;

            _tvCounter.Text = $"{_counter}";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}