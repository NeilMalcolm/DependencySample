using DependencyHelper.Pages;
using DependencyHelper.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DependencyHelper
{
    public partial class App : Application
    {
        public static DependencyHelper DependencyService = new DependencyHelper();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(DependencyService.Get<INavigationService>().GetPageWithViewModel<MainPage>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
