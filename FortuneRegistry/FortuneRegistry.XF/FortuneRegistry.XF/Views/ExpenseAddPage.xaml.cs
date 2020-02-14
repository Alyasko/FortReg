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
            AddExpenseCarousel.ScrollToRequested += AddExpenseCarouselOnScrollToRequested;

            _vm.StepChanged += StepChanged;

            _vm.ScrollToStep(0);
        }

        private void AddExpenseCarouselOnScrollToRequested(object sender, ScrollToRequestEventArgs e)
        {
            if (_vm.IsFirstStep)
                BtnCancel.Text = "Cancel";
            else if (!_vm.IsFirstStep && !_vm.IsLastStep)
                BtnCancel.Text = "Back";

            BtnNext.Text = _vm.IsLastStep ? "Save" : "Next";
        }

        private void StepChanged(object sender, AddExpenseSteppingEventArgs e)
        {
            AddExpenseCarousel.ScrollTo(e.NewStep);
        }

        private async void BtnNext_Clicked(object sender, System.EventArgs e)
        {
            if (_vm.IsLastStep)
            {
                await Navigation.PopModalAsync();
                return;
            }

            _vm.NextStep();
        }

        private async void BtnCancel_Clicked(object sender, System.EventArgs e)
        {
            if (_vm.IsFirstStep)
            {
                await Navigation.PopModalAsync();
                return;
            }

            _vm.PreviousStep();
        }
    }
}
