using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views.ExpenseAdd
{
    public partial class AddExpenseStep3ContentView : ContentView
    {
        public static AddExpenseStep3ContentView I { get; private set; }

        public AddExpenseStep3ContentView()
        {
            InitializeComponent();

            I = this;
        }

        public Object DataContext { get; set; }
    }
}
