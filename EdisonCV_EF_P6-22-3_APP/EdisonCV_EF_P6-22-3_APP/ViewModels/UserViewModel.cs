using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Newtonsoft.Json;
using RestSharp;
using EdisonCV_EF_P6_22_3_APP.Models;


namespace EdisonCV_EF_P6_22_3_APP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

       

        public User MyUsuario { get; set; }

        public UserDTO MyUsuarioDTO { get; set; }
        public UserViewModel()
        {
          
         
            MyUsuario = new User();
            MyUsuarioDTO = new UserDTO();
        }


       

        public async Task<UserDTO> GetUserData(int id)
        {

            try
            {
                UserDTO user = new UserDTO();


                user = await MyUsuarioDTO.GetUserData(id);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
      

        public async Task<bool> ValidateUserData(int id)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
             

                bool R = await MyUsuario.ValidateUser(id);

                return R;

            }
            catch (Exception)
            {

                return false;
                throw;
            }
            finally
            { IsBusy = false; }


        }








        //funcion de ingreso al app del usuario




    }


  
}
