using System;
namespace FortuneRegistry.XF.Models
{
    public class AddExpenseSteppingEventArgs : EventArgs
    {
        public AddExpenseSteppingEventArgs()
        {
        }

        public int NewStep { get; set; }
    }
}
