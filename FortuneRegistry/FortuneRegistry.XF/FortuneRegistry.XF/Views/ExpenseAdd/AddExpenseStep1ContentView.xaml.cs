using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views.ExpenseAdd
{
    public partial class AddExpenseStep1ContentView : ContentView
    {
        public static AddExpenseStep1ContentView I { get; private set; }

        public AddExpenseStep1ContentView()
        {
            InitializeComponent();

            I = this;
        }

        public Object DataContext { get; set; }

        //public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>() { "Food", "Internet", "Transport" };
        //public List<string> Subcategories { get; set; } = new List<string>() { "Food", "Internet", "Transport" };
    }
}
