using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EdisonCV_EF_P6_22_3_APP.Models
{
    public partial class User
    {



        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";





        public User()
        {
          
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string UserPassword { get; set; } = null!;
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; } = null!;
        public string? JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual UserRole UserRole { get; set; } = null!;
        public virtual UserStatus UserStatus { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Like> Likes { get; set; }



       


        public async Task<bool> ValidateUser(int id)
        {

            try
            {
                string RouteSufix = string.Format("Users/{0}",
                                  id);
                string FinalURL = Services.CnnToApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToApi.ApiKeyName, Services.CnnToApi.ApiKeyValue);
                request.AddHeader(contentype, mimetype);


                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de info en un json

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;

                //to do guardar errores en una bitacora.
                throw;
            }

        }


    }
}
