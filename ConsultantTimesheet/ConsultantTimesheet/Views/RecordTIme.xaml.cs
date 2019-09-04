using ConsultantTimesheet.Models;
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
            public static string LOCATION; // Unmodifiable
            public static string CLOCKIN; // Unmodifiable
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
                    String locationdetail = placemark.CountryName + ", " + placemark.Locality + ", " + placemark.SubLocality + ", " + placemark.PostalCode;
                    geolocationValue.Text = locationdetail;
                    Globals.LOCATION = locationdetail;
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
            Globals.CLOCKIN = datepick.Date.ToString("yyyy-MM-dd");


           /* var contact = new RecordTimeModel
            {
                CheckIndate = Globals.CLOCKIN,
                Location = Globals.LOCATION

            };*/
            var response = await apiService.RecordTimePost(Globals.CLOCKIN, timepick.Time.ToString(), Globals.LATITIDE, Globals.LONGITUDE);
            if (!response)
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
                /*var clockInRecorded = new ClockInRecorded();
                clockInRecorded.BindingContext = contact;
                await Navigation.PushAsync(new ClockInRecorded(clockInRecorded));*/
               
               
            }
            else
            {

                await DisplayAlert("Sucess", "Post Sucess", "Alright");
                Application.Current.MainPage = new ClockInRecorded();
            }

        }     
    }
}