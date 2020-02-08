using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FortuneRegistry.XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage()
        {
            InitializeComponent();
        }

        public async void BtnAddExpense_Clicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Info", "Hello!", "OK");
            await Navigation.PushModalAsync(new ExpenseAddPage());
        }
    }
}