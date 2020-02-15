using FortuneRegistry.XF.Views.ExpenseAdd;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Helpers
{
    public class AddExpenseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Step1DataTemplate { get; set; }
        public DataTemplate Step2DataTemplate { get; set; }
        public DataTemplate Step3DataTemplate { get; set; }

        public AddExpenseDataTemplateSelector(object template1, object template2, object template3)
        {
            Step1DataTemplate = new DataTemplate(() => template1);
            Step2DataTemplate = new DataTemplate(() => template2);
            Step3DataTemplate = new DataTemplate(() => template3);
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is AddExpenseStep1ContentView)
                return Step1DataTemplate;
            if (item is AddExpenseStep2ContentView)
                return Step2DataTemplate;
            if (item is AddExpenseStep3ContentView)
                return Step3DataTemplate;

            return null;
        }
    }
}
