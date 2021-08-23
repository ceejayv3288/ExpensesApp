using ExpensesApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath)
        {
            InitializeComponent();

            DatabasePath = databasePath;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            string androidAppSecret = "bbffab18-8fd5-46a1-984a-09e4f831aeb3";
            string iOSAppSecret = "9f2f71f8-53a9-466f-b256-c73a7ccc2172";
            AppCenter.Start($"android={androidAppSecret}; ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));

            bool didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
