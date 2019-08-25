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
            GeoLocation();           
        }

        private async void GeoLocation()
        {
            try
            {
                
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    geolocationValue.Text = placemark.CountryName + placemark.Locality + placemark.SubLocality;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}