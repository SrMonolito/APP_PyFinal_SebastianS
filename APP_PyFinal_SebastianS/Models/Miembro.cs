using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.Models
{
    public class Miembro
    {
        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int MiembroId { get; set; }

        public int RolId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Telefono { get; set; }

        public async Task<List<Miembro>> GetMiembrosAsync()
        {
            try
            {
                string RouteSufix = string.Format("TblMiembroes");
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //se agrega la info de seguridad del apikey
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                //ejecutamos la llamada
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<Miembro>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<bool?> AddMiembroAsync()
        {
            try
            {

                string RouteSufix = string.Format("TblMiembroes");
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos la info de seguridad api key 
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                //cuando enviamos objetos hacie el API debemos serializarlos antes

                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel);

                //se ejecuta la llamada 
                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado al API 
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<Miembro?> BuscarProyectoByIdAsync(int miembroId)
        {
            try
            {
                string RouteSufix = string.Format("TblMiembroes/{0}", miembroId);

                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //se agrega la info de seguridad del apikey
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);



                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.OK)
                {
                    var miembro = JsonConvert.DeserializeObject<Miembro>(response.Content);
                    return miembro;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<bool> ModificarMiembroAsync(Miembro miembro)
        {
            try
            {
                // Usa string.Format para construir la URL
                string RouteSufix = string.Format("TblProyectos/{0}", miembro.MiembroId);
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);
                RestRequest request = new RestRequest(URL, Method.Put);

                // Se agrega la información de seguridad del apikey
                request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                // Serializa el proyecto a JSON y agrega el cuerpo de la solicitud
                string SerializedModel = JsonConvert.SerializeObject(miembro);
                request.AddJsonBody(SerializedModel);

                RestResponse response = await client.ExecuteAsync(request);
                HttpStatusCode statusCode = response.StatusCode;

                return statusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                string message = ex.Message;
                throw;
            }
        }

    }
}
