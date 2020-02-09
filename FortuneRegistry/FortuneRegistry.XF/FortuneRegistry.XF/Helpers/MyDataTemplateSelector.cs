
using FortuneRegistry.XF.ViewModels;
using FortuneRegistry.XF.Views.ExpenseAdd;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Helpers
{
    public class AddExpenseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Step1DataTemplate { get; set; }
        public DataTemplate Step2DataTemplate { get; set; }
        public DataTemplate Step3DataTemplate { get; set; }

        public AddExpenseDataTemplateSelector()
        {
            Step1DataTemplate = new DataTemplate(typeof(AddExpenseStep1ContentView));
            Step2DataTemplate = new DataTemplate(typeof(AddExpenseStep2ContentView));
            Step3DataTemplate = new DataTemplate(typeof(AddExpenseStep3ContentView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var cell = (int)item;

            switch(cell)
            {
                case 1:
                    return Step1DataTemplate;
                case 2:
                    return Step2DataTemplate;
                case 3:
                    return Step3DataTemplate;
                default:
                    return null;
            }
        }
    }
}
