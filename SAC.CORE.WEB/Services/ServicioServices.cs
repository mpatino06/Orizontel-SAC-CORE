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
    public class ServicioServices : Helper
    {
        private HttpClient client;
        private string PathServer { get; set; }

        public ServicioServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 25600000;
            PathServer = GetUrlPathApi();
        }

        public async Task<List<Tiposervicio>> GetTipoServicio()
        {
            var items = new List<Tiposervicio>();
            string url = PathServer + "sac/servicio/GetTipoServicio";
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Tiposervicio>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<Servicio>> GetServicioByTipoServicio(int Id)
        {
            var items = new List<Servicio>();
            string url = PathServer + "sac/servicio/GetServicioByTipoServicio/" + Id;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Servicio>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<AfiliacionServicios>> GetAfiliacionByIdentificacion(string identificacion)
        {
            var items = new List<AfiliacionServicios>();
            string url = PathServer + "sac/servicio/GetAfiliacion/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<AfiliacionServicios>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<AfiliacionServicios> GetAfiliacionById(int Id)
        {
            var items = new AfiliacionServicios();
            string url = PathServer + "sac/servicio/GetAfiliacionById/" + Id;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<AfiliacionServicios>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<bool> UpdateAfiliacion(AfiliacionServicios afiliacion)
        {
            bool items = false;
            string url = PathServer + "/sac/servicio/UpdateAfiliacion";
            try
            {
                var json = JsonConvert.SerializeObject(afiliacion);
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

        public async Task<bool> DeleteAfiliacion(int Idafiliacion)
        {
            bool items = false;
            string url = PathServer + "/sac/servicio/DeleteAfiliacion/" + Idafiliacion.ToString();
            try
            {
                var result = await client.GetAsync(url);
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

        //public async Task<int> SaveSolicitudPrestamo(TransferenciaAfiliacion afiliacion)
        //{
        //    int items = 0;
        //    string url = PathServer + "/sac/servicio/SaveAfiliacion";
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(afiliacion);
        //        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        //        HttpResponseMessage result = await client.PostAsync(url, content);

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var x = await result.Content.ReadAsStringAsync();
        //            items = JsonConvert.DeserializeObject<int>(x);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error {0}", ex.Message.ToString());
        //    }
        //    return items;
        //}

        public async Task<int> SaveAfiliacion(Afiliacion afiliacion)
        {
            int items = 0;
            string url = PathServer + "/sac/servicio/SaveAfiliacion";
            try
            {
                var json = JsonConvert.SerializeObject(afiliacion);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(url, content);

                if (result.IsSuccessStatusCode)
                {
                    var x = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<int>(x);
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