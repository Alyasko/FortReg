using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FortuneRegistry.XamarinForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private int _counter;
        
        public MainPage()
        {
            InitializeComponent();

            _counter = 0;
        }
        
        public void Button_OnClicked(object sender, EventArgs e)
        {
            _counter++;
            lblCounter.Text = $"Counter: {_counter}";
        }
    }
}
