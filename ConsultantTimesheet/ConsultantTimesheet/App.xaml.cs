using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultantTimesheet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();

            if (!string.IsNullOrEmpty(Preferences.Get("DeviceToken", "")))
            {
                MainPage = new MainPage();
            }
            else if (string.IsNullOrEmpty(Preferences.Get("UserEmail", "")) && string.IsNullOrEmpty(Preferences.Get("UserPassword", "")))
            {
                MainPage = new NavigationPage(new Login());
            }

           MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
