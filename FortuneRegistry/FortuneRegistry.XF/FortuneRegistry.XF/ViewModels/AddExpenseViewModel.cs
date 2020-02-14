using System;
using System.Collections.Generic;
using FortuneRegistry.XF.Models;

namespace FortuneRegistry.XF.ViewModels
{
    public class AddExpenseViewModel
    {
        public AddExpenseViewModel()
        {
        }

        public EventHandler<AddExpenseSteppingEventArgs> StepChanged;

        public void SetStep(int step)
        {
            CurrentStep = step;

            var handler = StepChanged;
            handler?.Invoke(this, new AddExpenseSteppingEventArgs() { NewStep = CurrentStep });
        }

        public int CurrentStep { get; private set; }

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

        public List<int> Steps = new List<int>()
            {
                1,
                2,
                3
            };
    }
}
