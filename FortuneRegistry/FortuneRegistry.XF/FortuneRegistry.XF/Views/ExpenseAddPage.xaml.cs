using System;
using System.Collections.Generic;
using System.Diagnostics;
using FortuneRegistry.XF.Helpers;
using FortuneRegistry.XF.Models;
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

            AddExpenseCarousel.ItemsSource = _vm.Steps;
            AddExpenseCarousel.IsSwipeEnabled = false;

            _vm.StepChanged += StepChanged;

            _vm.ScrollToStep(0);
        }

        private void StepChanged(object sender, AddExpenseSteppingEventArgs e)
        {
            AddExpenseCarousel.ScrollTo(e.NewStep);
            Debug.WriteLine(e.NewStep);
        }

        void BtnNext_Clicked(System.Object sender, System.EventArgs e)
        {
            _vm.NextStep();
        }

        void BtnCancel_Clicked(System.Object sender, System.EventArgs e)
        {
            _vm.PreviousStep();
        }
    }
}
