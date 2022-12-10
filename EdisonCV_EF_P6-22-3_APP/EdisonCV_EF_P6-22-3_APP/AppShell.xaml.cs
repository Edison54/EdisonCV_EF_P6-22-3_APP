using EdisonCV_EF_P6_22_3_APP;
using EdisonCV_EF_P6_22_3_APP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EdisonCV_EF_P6_22_3_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
