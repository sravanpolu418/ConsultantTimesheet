﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultantTimesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneTimePassword : ContentPage
    {
        public OneTimePassword()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TabbedPage1();
        }
    }
}