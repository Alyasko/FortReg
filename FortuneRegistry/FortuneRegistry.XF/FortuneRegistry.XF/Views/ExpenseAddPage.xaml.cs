using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FortuneRegistry.XF.Helpers;
using FortuneRegistry.XF.Models;
using FortuneRegistry.XF.ViewModels;
using FortuneRegistry.XF.Views.ExpenseAdd;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views
{
    public partial class ExpenseAddPage : ContentPage
    {
        private readonly AddExpenseViewModel _vm = new AddExpenseViewModel();

        public ExpenseAddPage()
        {
            InitializeComponent();

            BindingContext = _vm;

            var list = new List<object>()
            {
                new AddExpenseStep1ContentView() {DataContext = _vm},
                new AddExpenseStep2ContentView() {DataContext = _vm},
                new AddExpenseStep3ContentView() {DataContext = _vm}
            };

            AddExpenseCarousel.ItemTemplate = new AddExpenseDataTemplateSelector(list[0], list[1], list[2]);

            AddExpenseCarousel.ItemsSource = list;
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

            var ir = AddExpenseCarousel.ItemTemplate as AddExpenseDataTemplateSelector;

            var t1 = ir.Step1DataTemplate.Values.FirstOrDefault();
            var t2 = ir.Step2DataTemplate;
            var t3 = ir.Step3DataTemplate;

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
