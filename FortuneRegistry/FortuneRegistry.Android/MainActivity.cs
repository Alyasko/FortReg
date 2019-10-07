using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Android.Text;
using FortuneRegistry.Android.Model;
using FortuneRegistry.Shared.Client.Model;

namespace FortuneRegistry.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner _spCategory;
        private Spinner _spCurrency;

        private Button _btnAdd;

        private EditText _etDescription;
        private EditText _etAmount;

        private Registry _registry;

        private string _selectedCurrency;
        private string _selectedCategory;

        private readonly List<string> _categories = new List<string>();
        private readonly List<string> _currencies = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            var googleSheetsClient = new GoogleSheetsClient(new AndroidGSheetConfigProvider(Assets));
            _registry = new Registry(googleSheetsClient);

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Setup.

            // Buttons.
            _btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            _btnAdd.Click += BtnAddOnClick;

            // Edit Texts.
            _etDescription = FindViewById<EditText>(Resource.Id.editTextDescription);
            _etDescription.SetRawInputType(InputTypes.ClassText | InputTypes.TextFlagCapSentences);

            _etAmount = FindViewById<EditText>(Resource.Id.editTextAmount);
            _etAmount.SetRawInputType(InputTypes.ClassNumber);

            // Spinner Category.
            _spCategory = FindViewById<Spinner>(Resource.Id.spinnerCategory);
            _spCategory.ItemSelected += SpCategoryOnItemSelected;

            _categories.AddRange(_registry.QueryAllCategories());
            var adapterCategories = new ArrayAdapter<string>(this,
                Android.Resource.Layout.support_simple_spinner_dropdown_item, _categories);
            adapterCategories.SetDropDownViewResource(Android.Resource.Layout.support_simple_spinner_dropdown_item);
            _spCategory.Adapter = adapterCategories;

            // Spinner Currency.
            _spCurrency = FindViewById<Spinner>(Resource.Id.spinnerCurrency);
            _spCurrency.ItemSelected += SpCurrencyOnItemSelected;

            _currencies.AddRange(_registry.QueryAllCurrencies());
            var adapterCurrencies = new ArrayAdapter<string>(this,
                Android.Resource.Layout.support_simple_spinner_dropdown_item, _currencies);
            adapterCurrencies.SetDropDownViewResource(Android.Resource.Layout.support_simple_spinner_dropdown_item);
            _spCurrency.Adapter = adapterCurrencies;
        }

        private void BtnAddOnClick(object sender, EventArgs e)
        {
            if(!ValidateInput())
                return;

            _registry.SaveExpense(_etAmount.Text, _selectedCurrency, _selectedCategory, _etDescription.Text);

            Toast.MakeText(this, "Item added", ToastLength.Long).Show();

            _etAmount.Text = "";
            _etDescription.Text = "";
        }

        private void SpCurrencyOnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = (Spinner)sender;
            _selectedCurrency = spinner.GetItemAtPosition(e.Position).ToString();
        }

        private void SpCategoryOnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = (Spinner)sender;
            _selectedCategory = spinner.GetItemAtPosition(e.Position).ToString();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_etAmount.Text))
            {
                Toast.MakeText(this, "Please enter transaction amount.", ToastLength.Long).Show();
                return false;
            }
            if (string.IsNullOrWhiteSpace(_etDescription.Text))
            {
                Toast.MakeText(this, "Please enter transaction description.", ToastLength.Long).Show();
                return false;
            }

            return true;
        }
    }
}