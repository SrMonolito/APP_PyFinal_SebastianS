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
    public class Comentario
    {
        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int TareaId { get; set; }

        public int MiembroId { get; set; }

        public int ComentarioId { get; set; }

        public DateOnly Fecha { get; set; }

        public string Comentariotxt { get; set; } = null!;


        public async Task<List<Comentario>?> GetComentariosAsync()
        {
            try
            {
                //este es el sufijo que termina la ruta de consumo del API

                string RouteSufix = string.Format("TblComentarios");

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
                    var list = JsonConvert.DeserializeObject<List<Comentario>>(response.Content);

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

        public async Task<bool?> AddComentarioAsync()
        {
            try
            {
                string RouteSufix = string.Format("TblComentarios");

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

        public async Task<Comentario?> BuscarComentarioByIdAsync(int comentarioId)
        {
            try
            {
                string RouteSufix = string.Format("TblComentarios/{0}", comentarioId);

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
                    var comentario = JsonConvert.DeserializeObject<Comentario>(response.Content);
                    return comentario;
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

        public async Task<bool> ModificarComentarioAsync(Comentario comentario)
        {
            try
            {
                // Usa string.Format para construir la URL
                string RouteSufix = string.Format("TblComentarios/{0}", comentario.ComentarioId);
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);
                RestRequest request = new RestRequest(URL, Method.Put);

                // Se agrega la información de seguridad del apikey
                request.AddHeader(Services.WebAPIConnection.ApiKeyName,
                                  Services.WebAPIConnection.ApiKeyValue);

                // Serializa el comentario a JSON y agrega el cuerpo de la solicitud
                string SerializedModel = JsonConvert.SerializeObject(comentario);
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
