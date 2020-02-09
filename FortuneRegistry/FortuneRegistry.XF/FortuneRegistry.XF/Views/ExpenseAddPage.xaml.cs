using System;
using System.Collections.Generic;
using FortuneRegistry.XF.Helpers;
using FortuneRegistry.XF.ViewModels;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views
{
    public partial class ExpenseAddPage : ContentPage
    {
        private readonly AddExpenseViewModel _vm = new AddExpenseViewModel();

        public ExpenseAddPage()
        {
            InitializeComponent();

            _vm.CurrentStep = 1;
            TheCarousel.ItemsSource = new List<int>()
            {
                1,
                2,
                3
            };
            //List<CustomCell> myCarousel = new List<CustomCell>();
            //myCarousel.Add(new CustomCell { Testo = "ciao" });
            //myCarousel.Add(new CustomCell { Testo = "ciao due" });

            //TheCarousel.ItemsSource = myCarousel;
        }
    }
}
