using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FortuneRegistry.XF.Models;

namespace FortuneRegistry.XF.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private readonly Dictionary<MenuItemType, NavigationPage> _menuPages = new Dictionary<MenuItemType, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            _menuPages.Add(MenuItemType.Dashboard, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType menuItem)
        {
            if (!_menuPages.ContainsKey(menuItem))
            {
                switch (menuItem)
                {
                    case MenuItemType.Dashboard:
                        _menuPages.Add(MenuItemType.Dashboard, new NavigationPage(new DashboardPage()));
                        break;
                    case MenuItemType.Income:
                        _menuPages.Add(MenuItemType.Income, new NavigationPage(new IncomePage()));
                        break;
                    case MenuItemType.Expenses:
                        _menuPages.Add(MenuItemType.Expenses, new NavigationPage(new ExpensesPage()));
                        break;
                    case MenuItemType.Settings:
                        _menuPages.Add(MenuItemType.Settings, new NavigationPage(new SettingsPage()));
                        break;
                    case MenuItemType.About:
                        _menuPages.Add(MenuItemType.About, new NavigationPage(new AboutPage()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(menuItem), menuItem, null);
                }
            }

            var newPage = _menuPages[menuItem];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}