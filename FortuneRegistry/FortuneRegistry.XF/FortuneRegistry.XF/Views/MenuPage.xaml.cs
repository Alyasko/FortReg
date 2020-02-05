using FortuneRegistry.XF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FortuneRegistry.XF.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage => Application.Current.MainPage as MainPage;

        private readonly List<HomeMenuItem> _menuItems = new List<HomeMenuItem>
        {
            new HomeMenuItem {Id = MenuItemType.Dashboard, Title="Dashboard" },
            new HomeMenuItem {Id = MenuItemType.Income, Title="Income" },
            new HomeMenuItem {Id = MenuItemType.Expenses, Title="Expenses" },
            new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings" },
            new HomeMenuItem {Id = MenuItemType.About, Title="About" }
        };

        public MenuPage()
        {
            InitializeComponent();

            LvMenuItems.ItemsSource = _menuItems;

            LvMenuItems.SelectedItem = _menuItems[0];
        }

        private async void LvMenuItems_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || RootPage == null)
                return;

            var id = ((HomeMenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
        }
    }
}