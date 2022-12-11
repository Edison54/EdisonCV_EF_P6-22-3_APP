using EdisonCV_EF_P6_22_3_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EdisonCV_EF_P6_22_3_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AskPage : ContentPage
    {




        AskViewModel vm;



   
            public AskPage()



            {
                this.BindingContext = vm = new AskViewModel();
                InitializeComponent();
        }


        private bool UserImputValidation()
        {
            bool R = false;
            if (TxtAsk.Text != null && !string.IsNullOrEmpty(TxtAsk.Text.Trim()) &&
               TxtAskDetail.Text != null && !string.IsNullOrEmpty(TxtAskDetail.Text.Trim()) &&
               TxtPhoto.Text != null && !string.IsNullOrEmpty(TxtPhoto.Text.Trim()))
             

            {
                R = true;

            }
            else
            {

                if (TxtAsk.Text == null || string.IsNullOrEmpty(TxtAsk.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "La pregunta es requerida", "OK");
                    TxtAsk.Focus();
                    return false;
                }
                if (TxtAskDetail.Text == null || string.IsNullOrEmpty(TxtAskDetail.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "La pregunta es requerida", "OK");
                    TxtAskDetail.Focus();
                    return false;
                }
                if (TxtPhoto.Text == null || string.IsNullOrEmpty(TxtPhoto.Text.Trim()))
                {
                    DisplayAlert("Error de validacion", "La pregunta es requerida", "OK");
                    TxtPhoto.Focus();
                    return false;
                }
                


            }

            return R;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserImputValidation())
            {




                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
                var answer = await DisplayAlert("Quieres crear una pregunta?", "Estas seguro?", "Si", "No");

                if (answer)
                {

                    bool R = await vm.AddNewASK(
             TxtAsk.Text.Trim(),
             TxtAskDetail.Text.Trim(),
             TxtPhoto.Text.Trim(),
             TxtDate.Date
           
               );

                    if (R)
                    {
                        await DisplayAlert("Felicidades", "Tu pregunta se creo correctamente", "OK");
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await DisplayAlert("Error", "Tu precunta no pudo ser creada", "OK");
                    }
                }
            }
        }

        private void BtnAdd_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}