using Newtonsoft.Json;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.WEB.Infrastructure;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Services
{
    public class UserServices : Helper
    {
        private HttpClient client;
        private string PathServer { get; set; }

        public UserServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            PathServer = GetUrlPathApi();
        }

        public async Task<PersonaDetalle> GetUser(string code)
        {
            var items = new PersonaDetalle();
            string url = PathServer + "sac/usuario/GetByIdentificacion/" + code;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<PersonaDetalle>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<bool> UpdateUser(AdminUsuario user)
        {
            bool items = true;
            string url = PathServer + "sac/usuario/UpdateUsuario";
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(url, content);

                if (result.IsSuccessStatusCode)
                {
                    var x = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<bool>(x);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }
    }
}