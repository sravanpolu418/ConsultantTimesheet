using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultantTimesheet.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultantTimesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }      

        private async void Button_Clicked(object sender, EventArgs e)
        {
            APIService apiService = new APIService();
            var response= await apiService.LoginAsync(email.Text, pwd.Text);        
            if (response.status == "Success")
            {

                Preferences.Set("UserEmail", email.Text);
                Preferences.Set("UserPassword", pwd.Text);
                Preferences.Set("DeviceToken", response.records[0].DeviceToken);
                Application.Current.MainPage = new OneTimePassword();
               
            }
            else
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
        }
    }
}