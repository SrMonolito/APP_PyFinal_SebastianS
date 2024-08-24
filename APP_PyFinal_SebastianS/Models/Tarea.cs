using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
namespace APP_PyFinal_SebastianS.Models
{
    public class Tarea
    {
        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int TareaId { get; set; }

        public int ProyectoId { get; set; }

        public string? Nombre { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public string Descripcion { get; set; } = null!;

        public string? Estado { get; set; }


        public async Task<List<Tarea>?> GetTareasAsync()
        {
            try
            {
                //este es el sufijo que termina la ruta de consumo del API

                string RouteSufix = string.Format("TblTareas");

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
                    var list = JsonConvert.DeserializeObject<List<Tarea>>(response.Content);

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

        public async Task<bool?> AddTareaAsync()
        {
            try
            {
                string RouteSufix = string.Format("TblTareas");

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

        public async Task<Tarea?> BuscarTareaByIdAsync(int tareaId)
        {
            try
            {
                string RouteSufix = string.Format("TblTareas/{0}", tareaId);

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
                    var tarea = JsonConvert.DeserializeObject<Tarea>(response.Content);
                    return tarea;
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

        public async Task<bool> ModificarTareaAsync(Tarea tarea)
        {
            try
            {
                // Usa string.Format para construir la URL
                string RouteSufix = string.Format("TblTareas/{0}", tarea.TareaId);
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);
                RestRequest request = new RestRequest(URL, Method.Put);

                // Se agrega la información de seguridad del apikey
                request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                // Serializa el tarea a JSON y agrega el cuerpo de la solicitud
                string SerializedModel = JsonConvert.SerializeObject(tarea);
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
