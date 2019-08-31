using ConsultantTimesheet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultantTimesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordTIme : ContentPage
    {
        public RecordTIme()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            GeoLocationAsync();           
        }

        public static class Globals
        {

            public static string LATITIDE; // Modifiable
            public static string LONGITUDE; // Unmodifiable
        }



        public async void GeoLocationAsync()
        {           
            try
            {               
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                Globals.LATITIDE = location.Latitude.ToString();
                Globals.LONGITUDE = location.Longitude.ToString();

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    geolocationValue.Text = placemark.CountryName + ", " + placemark.Locality + ", " + placemark.SubLocality + ", " + placemark.PostalCode;                  
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            APIService apiService = new APIService();
            var response = await apiService.RecordTimePost(datepick.Date.ToString(),timepick.Time.ToString(), Globals.LATITIDE, Globals.LONGITUDE);
            if (!response)
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {

                await DisplayAlert("Sucess", "Post Sucess", "Alright");
            }

        }

        /* private async Task Button_Clicked(object sender, EventArgs e)
         {
             RecordTIme test = new RecordTIme();
             Location loc =await test.GeoLocation();


         }*/
    }
}