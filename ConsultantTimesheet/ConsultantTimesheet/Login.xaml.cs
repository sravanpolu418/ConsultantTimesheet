using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultantTimesheet.Services;

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
            if (!response)
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
               
                Application.Current.MainPage = new OneTimePassword();
            }
        }
    }
}