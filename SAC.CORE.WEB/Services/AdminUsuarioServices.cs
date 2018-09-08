using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.WEB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Services
{
    public class AdminUsuarioServices : Helper
    {
        private HttpClient client;
        private string PathServer { get; set; }

        public AdminUsuarioServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2560000;
            PathServer = GetUrlPathApi();
        }

        public async Task<AdminUsuario> GetUser(string code, string pass, bool save)
        {
            var items = new AdminUsuario();
            string url = PathServer + "sac/AdminUsuario/GetUsuario/" + code + "/" + pass + "/" + save;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<AdminUsuario>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<AdminUsuario> GetValidateUser(string codigo, string user, DateTime fec)
        {
            var items = new AdminUsuario();
            string url = PathServer + "sac/AdminUsuario/ValidateUser/" + codigo + "/" + user + "/" + fec.ToString().Replace("/", "-");
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<AdminUsuario>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<AdminUsuario> Save(AdminUsuario usuario)
        {
            var items = new AdminUsuario();
            string url = PathServer + "/sac/AdminUsuario/PostUsuario";
            try
            {
                var convertJsonObj = new StringContent(JsonConvert.SerializeObject(usuario), System.Text.Encoding.UTF8, "application/json");

                var result = await client.PostAsync(url, convertJsonObj);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<AdminUsuario>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<bool> Update(AdminUsuario usuario)
        {
            bool items = false;
            string url = PathServer + "/sac/Usuario/UpdateUsuario";
            try
            {
                var convertJsonObj = new StringContent(JsonConvert.SerializeObject(usuario), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, convertJsonObj);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<AdminUsuario> GetUserByNameAndIdenticacion(string code)
        {
            var items = new AdminUsuario();
            string url = PathServer + "sac/usuario/GetByNameAndIdentificacion/" + code;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<AdminUsuario>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<Preguntaseguridad>> GetAllPreguntas()
        {
            var items = new List<Preguntaseguridad>();
            string url = PathServer + "sac/usuario/getallpreguntas/";
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Preguntaseguridad>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        #region SelectListItems

        public List<SelectListItem> GetPreguntas(List<Preguntaseguridad> preguntas)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add((new SelectListItem { Value = "0", Text = "Seleccione pregunta de seguridad", Selected = true }));
            foreach (var item in preguntas)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Pregunta.ToString() });
            }

            return list;
        }

        #endregion SelectListItems
    }
}