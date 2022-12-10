using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EdisonCV_EF_P6_22_3_APP.ViewModels;

namespace EdisonCV_EF_P6_22_3_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {




        UserViewModel vm;



        public WelcomePage()
        {
            InitializeComponent();
            this.BindingContext = vm = new UserViewModel();
        }

        private async void BtnIngreso_Clicked(object sender, EventArgs e)
        {

            if (TxtID.Text != null) {

                bool R = false;

                R = await vm.ValidateUserData(Int32.Parse(TxtID.Text));

                if (R)
                {
                    try
                    {

                        //todo: cargar info en un objeto global tipo user (o userDTO)

                        GlobalObjects.GlobalUser = await vm.GetUserData(Int32.Parse(TxtID.Text));

                    }

                    catch (Exception ex)
                    {
                        await DisplayAlert("No se pudo crear el globalUser", ex.Message, "OK");
                        return;
                    }
                    await DisplayAlert("Su id es correcta Bienvenido", GlobalObjects.GlobalUser.FirstName, "OK");
                    await Navigation.PushAsync(new AskPage());
                    TxtID.Text = "";

                }
                else
                {

                    await DisplayAlert("ID INCORRECTA", "La id sumisnistrada no pertenece a ninguno de los usuarios en la BD", "OK");
                }









            }
            else
            {

                await DisplayAlert("Falta la ID", "La id sumisnistrada no puede estar vacia", "OK");
            }






        }
    }
}