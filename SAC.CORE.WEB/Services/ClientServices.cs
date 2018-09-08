using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Models;
using SAC.CORE.WEB.Infrastructure;
using SAC.CORE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Services
{
    public class ClientServices : Helper
    {
        private HttpClient client;
        private string PathServer { get; set; }

        public ClientServices()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 25600000
            };
            PathServer = GetUrlPathApi();
        }

        public async Task<CuentaSocio> GetCuentaSocio(string code)
        {
            var items = new CuentaSocio();
            string url = PathServer + "sac/cliente/GetCuentaSocio/" + code;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<CuentaSocio>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<PrestamoMaestros>> GetClienteMora(string code, DateTime fIni, DateTime fFin)
        {
            var items = new List<PrestamoMaestros>();
            string url = PathServer + "sac/cliente/GetClienteMora/" + code + "/" + fIni.ToString().Replace("/", "-") + "/" + fFin.ToString().Replace("/", "-");
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<PrestamoMaestros>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<ClienteMovimientoSaldos> GetMovimientosSaldo(string code)
        {
            var items = new ClienteMovimientoSaldos();
            string url = PathServer + "sac/cliente/GetMovimientoSaldos/" + code;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<ClienteMovimientoSaldos>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<ClienteDetalleCredito> GetDetalleCredito(string code)
        {
            var items = new ClienteDetalleCredito();
            string url = PathServer + "sac/cliente/GetClienteDetalle/" + code;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<ClienteDetalleCredito>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<ClienteConsolidado> GetClienteCuentas(string identificacion)
        {
            var items = new ClienteConsolidado();
            string url = PathServer + "sac/cliente/GetClienteCuentas/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<ClienteConsolidado>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<ClienteCuentaMovimientos>> GetMovimientosCuentas(int secuencial, string mes)
        {
            var items = new List<ClienteCuentaMovimientos>();

            string url = (mes == string.Empty) ? (PathServer + "sac/cliente/GetMovimientos/" + secuencial) : (PathServer + "sac/cliente/GetMovimientosbymes/" + secuencial + "/" + mes);
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ClienteCuentaMovimientos>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<ClienteCuentaMovimientos>> GetMovimientosCuentasByRange(int secuencial, string mesIni, string mesFin)
        {
            var items = new List<ClienteCuentaMovimientos>();

            string url = PathServer + "sac/cliente/GetMovimientosbyRange/" + secuencial + "/" + mesIni.Replace("/", "-") + "/" + mesFin.Replace("/", "-");
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ClienteCuentaMovimientos>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<PrestamosMovimientos>> GetMovimientosPrestamos(int prestamo)
        {
            var items = new List<PrestamosMovimientos>();
            string url = PathServer + "sac/cliente/GetMovimientosPrestamos/" + prestamo;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<PrestamosMovimientos>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<TransferenciaTercerosCuentas> GetCuentasTerceros(string identificacion)
        {
            var items = new TransferenciaTercerosCuentas();
            string url = PathServer + "sac/cliente/GetCuentasAfiliacionesTercero/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<TransferenciaTercerosCuentas>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<bool> SaveTransferencia(TransferenciaTerceros transferencia)
        {
            bool items = false;
            string url = PathServer + "/sac/cliente/SaveTransferencia";
            try
            {
                var json = JsonConvert.SerializeObject(transferencia);
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

        public async Task<bool> SaveDPF(DepositoPlazoFijo transferencia)
        {
            bool items = false;
            string url = PathServer + "/sac/cliente/SaveDPF";
            try
            {
                var json = JsonConvert.SerializeObject(transferencia);
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

        public async Task<List<PrestamoMaestros>> GetPrestamosByIdentificacion(string identificacion)
        {
            var items = new List<PrestamoMaestros>();
            string url = PathServer + "sac/cliente/GetPrestamosByIdentificacion/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<PrestamoMaestros>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<Tipoidentificacion>> GetIdentificacion()
        {
            var items = new List<Tipoidentificacion>();
            string url = PathServer + "sac/cliente/GetTipoIdentificacion";
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Tipoidentificacion>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<CuentasClienteAfiliacion> ValidarAfiliacion(string cuenta)
        {
            var items = new CuentasClienteAfiliacion();
            string url = PathServer + "sac/cliente/ValidarAfiliacion/" + cuenta;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<CuentasClienteAfiliacion>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<List<ClienteCuentas>> GetCuentas(string identificacion)
        {
            var items = new List<ClienteCuentas>();
            string url = PathServer + "sac/cliente/GetCuentas/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        public async Task<DepositoPlazoFijo> GetByPdf(int identificacion)
        {
            var items = new DepositoPlazoFijo();
            string url = PathServer + "sac/cliente/GetDpfById/" + identificacion;
            try
            {
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<DepositoPlazoFijo>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message.ToString());
            }
            return items;
        }

        #region SelectListItems

        public List<SelectListItem> GetCuentasCliente(List<ClienteCuentas> cuentas)
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                (new SelectListItem { Value = "0", Text = "Seleccione Cuenta", Selected = true })
            };
            foreach (var item in cuentas)
            {
                list.Add(new SelectListItem { Value = item.SecuencialCuentaMaestro.ToString(), Text = item.NombreTipoCuenta + " Cuenta: " + item.NumeroLibreta + " Saldo: " + item.SaldoCuenta.ToString() });
            }

            return list;
        }

        public List<SelectListItem> GetCuentasAfiliadas(List<CuentasClienteAfiliacion> cuentas)
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                (new SelectListItem { Value = "0", Text = "Seleccione Cuenta Afiliados", Selected = true })
            };
            foreach (var item in cuentas)
            {
                list.Add(new SelectListItem { Value = item.SecuencialCuenta.ToString(), Text = item.NombreUnido + " Cuenta: " + item.Libreta + " " + item.NombreAfiliado });
            }

            return list;
        }

        public List<SelectListItem> GetPrestamosCliente(List<PrestamoMaestros> prestamos)
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                (new SelectListItem { Value = "0", Text = "Seleccione prestamo", Selected = true })
            };
            foreach (var item in prestamos)
            {
                list.Add(new SelectListItem { Value = item.NUMEROPRESTAMO.ToString(), Text = item.NUMEROPRESTAMO.ToString() });
            }

            return list;
        }

        #endregion SelectListItems
    }
}