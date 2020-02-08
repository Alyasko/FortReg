using System;
using System.Collections.Generic;
using FortuneRegistry.XF.Helpers;
using Xamarin.Forms;

namespace FortuneRegistry.XF.Views
{
    public partial class ExpenseAddPage : ContentPage
    {
        public ExpenseAddPage()
        {
            InitializeComponent();

            List<CustomCell> myCarousel = new List<CustomCell>();
            myCarousel.Add(new CustomCell { Testo = "ciao" });
            myCarousel.Add(new CustomCell { Testo = "ciao due" });

            TheCarousel.ItemsSource = myCarousel;
        }
    }
}
