using EdisonCV_EF_P6_22_3_APP.Services;
using EdisonCV_EF_P6_22_3_APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EdisonCV_EF_P6_22_3_APP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

          
            MainPage = new NavigationPage(new WelcomePage());
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
