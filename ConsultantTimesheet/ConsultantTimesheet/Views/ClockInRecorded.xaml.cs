using ConsultantTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ConsultantTimesheet.Views.RecordTIme;

namespace ConsultantTimesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockInRecorded : ContentPage
    {
        

        public ClockInRecorded()
        {
            InitializeComponent();

            RecordTimeModel record = new RecordTimeModel();
            location.Text = Globals.LOCATION;
            clockin.Text = Globals.CLOCKIN;
            

        }
        
    }
}