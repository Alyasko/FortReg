using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views.ExpenseAdd
{
    public partial class AddExpenseStep2ContentView : ContentView
    {
        public static AddExpenseStep2ContentView I { get; private set; }

        public AddExpenseStep2ContentView()
        {
            InitializeComponent();

            I = this;
        }

        public Object DataContext { get; set; }
    }
}
