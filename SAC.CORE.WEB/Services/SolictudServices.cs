using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using SAC.CORE.WEB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Services
{
    public class SolictudServices : Helper
    {
        private HttpClient client;
        private string PathServer { get; set; }

        public SolictudServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 25600000;
            PathServer = GetUrlPathApi();
        }

        public async Task<GetInfoSolicitudPrestamo> GetDataSolicitudPrestamo()
        {
            var items = new GetInfoSolicitudPrestamo();
            string url = PathServer + "sac/solicitud/GetInfoSolicitud";
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<GetInfoSolicitudPrestamo>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<SolicitudPrestamo> SaveSolicitudPrestamo(SolicitudPrestamo solicitud)
        {
            var items = new SolicitudPrestamo(); ;
            string url = PathServer + "/sac/Solicitud/SaveSolicitudPrestamo";
            try
            {
                var json = JsonConvert.SerializeObject(solicitud);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(url, content);

                if (result.IsSuccessStatusCode)
                {
                    var x = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<SolicitudPrestamo>(x);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<SAC.CORE.API.Models.TipoPrestamo> GetTipoPrestamo(string name)
        {
            var items = new SAC.CORE.API.Models.TipoPrestamo();
            string url = PathServer + "sac/solicitud/GetTipoPrestamo/" + name;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<SAC.CORE.API.Models.TipoPrestamo>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<SolicitudPrestamo>> GetSolicitudByIdentificacion(string identificacion)
        {
            var items = new List<SolicitudPrestamo>();
            string url = PathServer + "sac/solicitud/GetSolicitudbyId/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<SolicitudPrestamo>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<PlazoFijoPeriodo>> GetPeriodoPlazoFijo()
        {
            var items = new List<PlazoFijoPeriodo>();
            string url = PathServer + "sac/servicio/GetPlazoFijoPeriodo";
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<PlazoFijoPeriodo>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<PlazoFijoTasas> GetPlazoFijoByMonto(int plazo, decimal monto)
        {
            var items = new PlazoFijoTasas();
            string url = PathServer + "sac/servicio/GetPlazoFijo/" + plazo.ToString() + "/" + monto.ToString();
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<PlazoFijoTasas>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<Depositomaestro>> GetListDpf(string secuencial)
        {
            var items = new List<Depositomaestro>();
            string url = PathServer + "sac/cliente/GetListDpf/" + secuencial;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Depositomaestro>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        #region SelectListItems

        public List<SelectListItem> GetTipoPrestamos(List<TipoPrestamo> prestamos)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add((new SelectListItem { Value = "0", Text = "Seleccione tipo Prestamo", Selected = true }));
            foreach (var item in prestamos)
            {
                list.Add(new SelectListItem { Value = item.Calificacionminimasolsobrediez.ToString(), Text = item.Nombre });
            }

            return list;
        }

        public List<SelectListItem> GetAmortizacion(List<Condiciontablaamortizacion> amortizacion)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var result = amortizacion.Take(2).Select(a => new { Nombre = a.Nombre, Codigo = a.Secuencial });

            list.Add((new SelectListItem { Value = "0", Text = "Seleccione Amortización", Selected = true }));
            foreach (var item in result)
            {
                list.Add(new SelectListItem { Value = item.Codigo.ToString(), Text = item.Nombre.ToString() });
            }

            return list;
        }

        public List<SelectListItem> GetPeriodoPF(List<PlazoFijoPeriodo> periodo)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add((new SelectListItem { Value = "0", Text = "Seleccione Periodo", Selected = true }));
            foreach (var item in periodo)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            }

            return list;
        }

        #endregion SelectListItems
    }
}