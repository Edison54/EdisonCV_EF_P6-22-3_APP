using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EdisonCV_EF_P6_22_3_APP.Models
{
    public partial class Ask
    {


        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";





        public Ask()
        {
           
        }

        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string AskDescription { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        public virtual AskStatus AskStatus { get; set; } = null!;
        public virtual User User { get; set; } = null!;
     
        public virtual ICollection<Answer> Answers { get; set; }

        public async Task<bool> AddAsk()
        {

            try
            {
                string RouteSufix = string.Format("Asks");
                string FinalURL = Services.CnnToApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToApi.ApiKeyName, Services.CnnToApi.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                string SerialClass = JsonConvert.SerializeObject(this, settings);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.Created)
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
