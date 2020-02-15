using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FortuneRegistry.XF.Models;

namespace FortuneRegistry.XF.ViewModels
{
    public class AddExpenseViewModel : BaseViewModel
    {
        public AddExpenseViewModel()
        {
            Currency = Currencies.FirstOrDefault();
        }

        public string AmountFormatted => $"{Amount:F2} {Currency}";

        public string CategoryFormatted
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Category) && string.IsNullOrWhiteSpace(Subcategory))
                    return Category;
                if (!string.IsNullOrWhiteSpace(Category) && !string.IsNullOrWhiteSpace(Subcategory))
                    return $"{Category}, {Subcategory}";

                return "";
            }
        }

        public ObservableCollection<string> Currencies { get; set; } = new ObservableCollection<string>()
        {
            "CHF",
            "EUR",
            "USD",
            "UAH",
            "RUB"
        };

        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>()
        {
            "Groceries",
            "Transport",
            "Food",
            "Gifts"
        };

        public ObservableCollection<string> Subcategories { get; set; } = new ObservableCollection<string>()
        {
            "Sweet",
            "Important",
        };

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CategoryFormatted));
            }
        }

        public string Subcategory
        {
            get => _subcategory;
            set
            {
                _subcategory = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CategoryFormatted));
            }
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AmountFormatted));
            }
        }

        public string Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AmountFormatted));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DescriptionFormatted));
            }
        }

        public string DescriptionFormatted => !string.IsNullOrWhiteSpace(Description) ? $"({Description})" : "";


        public EventHandler<AddExpenseSteppingEventArgs> StepChanged;

        public void ScrollToStep(int step)
        {
            CurrentStep = step;

            var handler = StepChanged;
            handler?.Invoke(this, new AddExpenseSteppingEventArgs() { NewStep = CurrentStep });
        }

        public int CurrentStep { get; set; }

        public void NextStep()
        {
            if (CurrentStep >= 2)
                return;

            CurrentStep++;

            var handler = StepChanged;
            handler?.Invoke(this, new AddExpenseSteppingEventArgs() { NewStep = CurrentStep });
        }

        public void PreviousStep()
        {
            if (CurrentStep <= 0)
                return;

            CurrentStep--;

            var handler = StepChanged;
            handler?.Invoke(this, new AddExpenseSteppingEventArgs() { NewStep = CurrentStep });
        }

        public bool IsLastStep => CurrentStep == Steps.Count - 1;

        public bool IsFirstStep => CurrentStep == 0;

        public List<int> Steps = new List<int>()
            {
                1,
                2,
                3
            };

        private string _category;
        private string _subcategory;
        private decimal _amount;
        private string _currency;
        private string _description;
    }
}
