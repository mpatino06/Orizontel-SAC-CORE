using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.WEB.Infrastructure;
using SAC.CORE.WEB.Models;
using SAC.CORE.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Controllers
{
    [SessionTimeout]
    public class ClientController : Controller
    {
        private ClientServices clientServices;

        public async Task<ActionResult> Index()
        {
            //ViewData["Section"] = "CuentaSocio";
            //return View();

            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _id = HttpContext.Session.GetString("IdentificacionCliente").ToString();
            var nombreUnido = HttpContext.Session.GetString("NombreCompleto").ToString();
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            clientServices = new ClientServices();
            var items = await clientServices.GetCuentaSocio(_id);

            if (items._Personas == null)
            {
                ViewBag.ExisteCuentaSocio = "False";
                return View();
            }

            ViewData["USerName"] = _codigoUsuario;
            ViewData["NombreUnido"] = nombreUnido;
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["Section"] = "CuentaSocio";

            return View("List", items);
        }

        public async Task<ActionResult> Consolidado()
        {
            clientServices = new ClientServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "Consolidado";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;

            var result = await clientServices.GetClienteCuentas(_identificacion);
            HttpContext.Session.SetString("NombreCompleto", result.NombreUnido);

            ViewData["NombreUnido"] = result.NombreUnido;

            return View(result);
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = TempData["list"] as CuentaSocio;

            return View(model);
        }

        public ActionResult Mora()
        {
            ViewData["Section"] = "ClientesMora";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Mora(DateTime datetimepickerIni, DateTime datetimepickerFin)
        {
            clientServices = new ClientServices();
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            var ID = HttpContext.Session.GetString("USerName1");
            var items = await clientServices.GetClienteMora(ID, datetimepickerIni, datetimepickerFin);

            ViewBag.Fini = datetimepickerIni.ToString().Replace(" 0:00:00", "");
            ViewBag.FFin = datetimepickerFin.ToString().Replace(" 0:00:00", "");

            ViewData["Section"] = "ClientesMora";
            return View("ListMora", items);
        }

        public async Task<ActionResult> MovimientosSaldos()
        {
            //ViewData["Section"] = "MovimientosSaldos";
            //return View();
            var ID = HttpContext.Session.GetString("IdentificacionCliente");
            ViewData["Section"] = "MovimientosSaldos";
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            clientServices = new ClientServices();
            var items = await clientServices.GetMovimientosSaldo(ID);
            if (items._PERSONAS == null)
            {
                ViewBag.ExisteMovimientos = "False";
                return View();
            }

            return View("MovimientosSaldosInfo", items);
        }

        [HttpPost]
        public async Task<ActionResult> MovimientosSaldos(string ID)
        {
            ViewData["Section"] = "MovimientosSaldos";
            clientServices = new ClientServices();
            var items = await clientServices.GetMovimientosSaldo(ID);
            if (items._PERSONAS == null)
            {
                ViewBag.ExisteMovimientos = "False";
                return View();
            }

            return View("MovimientosSaldosInfo", items);
        }

        public async Task<ActionResult> DetalleCredito()
        {
            clientServices = new ClientServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "DetalleCredito";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var prestamos = await clientServices.GetPrestamosByIdentificacion(_identificacion);

            ViewData["PrestamosCliente"] = clientServices.GetPrestamosCliente(prestamos);

            return View();
        }

        public async Task<ActionResult> Movimientos(int secuencial)
        {
            clientServices = new ClientServices();
            var items = await clientServices.GetMovimientosCuentas(secuencial, string.Empty);

            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            ViewData["USerName"] = HttpContext.Session.GetString("USerName1");
            ViewData["RutaImagen"] = HttpContext.Session.GetString("RutaImagen");
            ViewData["Section"] = "Consolidado";
            ViewData["Meses"] = GetMeses(DateTime.Now.ToString("MM"));
            ViewData["RadioCkd"] = "mes";
            ViewData["Init"] = "init";
            return View(items);
        }

        [HttpPost]
        public async Task<ActionResult> Movimientos(int secuencial, string Months, string survey, string dtpIni, string dtpFin)
        {
            clientServices = new ClientServices();
            List<ClienteCuentaMovimientos> items = new List<ClienteCuentaMovimientos>();

            if (survey == "mes")
            {
                items = await clientServices.GetMovimientosCuentas(secuencial, Months);
                ViewData["RadioCkd"] = "mes";
            }
            else if (survey == "rango")
            {
                items = await clientServices.GetMovimientosCuentasByRange(secuencial, dtpIni, dtpFin);
                ViewData["RadioCkd"] = "rango";
            }

            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            ViewData["USerName"] = HttpContext.Session.GetString("USerName1");
            ViewData["RutaImagen"] = HttpContext.Session.GetString("RutaImagen");
            ViewData["Section"] = "Consolidado";
            ViewData["Meses"] = GetMeses(Months);
            ViewData["MesIni"] = dtpIni;
            ViewData["MesFin"] = dtpFin;

            return View(items);
        }

        public async Task<ActionResult> MovimientoPrestamo(int prestamo)
        {
            clientServices = new ClientServices();
            var items = await clientServices.GetMovimientosPrestamos(prestamo);

            ViewData["NumeroPrestamo"] = (items.Count > 0) ? items.FirstOrDefault().NumeroPrestamo : "El Prestamo no tiene Movimientos";
            ViewData["USerName"] = HttpContext.Session.GetString("USerName1");
            ViewData["Section"] = "Consolidado";
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            //ViewBag.CodigoPrestamo

            return View(items);
        }

        [HttpPost]
        public async Task<ActionResult> DetalleCredito(string ID)
        {
            clientServices = new ClientServices();
            var items = await clientServices.GetDetalleCredito(ID);

            ViewData["Section"] = "DetalleCredito";
            if (items._CLIENTE == null)
            {
                ViewBag.ExisteDetalles = "False";
                return RedirectToAction("DetalleCredito");
            }

            return View("DetalleCreditoInfo", items);
        }

        public async Task<ActionResult> TransInterna()
        {
            clientServices = new ClientServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "TransInterna";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await clientServices.GetCuentasTerceros(_identificacion);

            ViewData["CtaDebitar"] = clientServices.GetCuentasCliente(result.CuentasCliente);
            ViewData["CtaAbonar"] = clientServices.GetCuentasAfiliadas(result.AfiliacionCliente);

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TransInterna(TransferenciaTercerosCuentas transferencia)
        {
            clientServices = new ClientServices();
            transferencia.IdentificacionCliente = HttpContext.Session.GetString("IdentificacionCliente");

            TransferenciaTerceros tfr = new TransferenciaTerceros
            {
                IdentificacionCliente = transferencia.IdentificacionCliente,
                SecuencialCuentaCliente = transferencia.SecuencialCuentaCliente,
                SecuencialCuentaAfiliado = transferencia.SecuencialCuentaAfiliado,
                Monto = transferencia.Monto,
                Concepto = transferencia.Concepto,
                Coordenada1 = transferencia.Coordenada1,
                Coordenada2 = transferencia.Coordenada2,
                TipoTransferencia = 1
            };

            bool result = await clientServices.SaveTransferencia(tfr);

            if (result)
            {
                return RedirectToAction("Consolidado");
            }

            return View();
        }

        public async Task<ActionResult> TransPropias()
        {
            clientServices = new ClientServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "TransPropias";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await clientServices.GetCuentasTerceros(_identificacion);

            ViewData["CtaDebitar"] = clientServices.GetCuentasCliente(result.CuentasCliente);
            ViewData["CtaAbonar"] = clientServices.GetCuentasAfiliadas(result.AfiliacionCliente);

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TransPropias(TransferenciaTercerosCuentas transferencia)
        {
            clientServices = new ClientServices();
            transferencia.IdentificacionCliente = HttpContext.Session.GetString("IdentificacionCliente");

            TransferenciaTerceros tfr = new TransferenciaTerceros
            {
                IdentificacionCliente = transferencia.IdentificacionCliente,
                SecuencialCuentaCliente = transferencia.SecuencialCuentaCliente,
                SecuencialCuentaAfiliado = transferencia.SecuencialCuentaAfiliado,
                Monto = transferencia.Monto,
                Concepto = transferencia.Concepto,
                Coordenada1 = transferencia.Coordenada1,
                Coordenada2 = transferencia.Coordenada2,
                TipoTransferencia = 2
            };

            bool result = await clientServices.SaveTransferencia(tfr);

            if (result)
            {
                return RedirectToAction("Consolidado");
            }

            return View();
        }

        public ActionResult PrintDocumento(string docu)
        {
            return View();
        }

        public List<SelectListItem> GetMeses(string mes)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //list.Add((new SelectListItem { Value = "0", Text = "Seleccione prestamo", Selected = true }));
            var mesactual = DateTime.Now.ToString("MM");

            list.Add(new SelectListItem { Value = "01", Text = "Enero", Selected = (("01" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "02", Text = "Febrero", Selected = (("02" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "03", Text = "Marzo", Selected = (("03" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "04", Text = "Abril", Selected = (("04" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "05", Text = "Mayo", Selected = (("05" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "06", Text = "Junio", Selected = (("06" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "07", Text = "Julio", Selected = (("07" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "08", Text = "Agosto", Selected = (("08" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "09", Text = "Septiembre", Selected = (("09" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "10", Text = "Octubre", Selected = (("10" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "11", Text = "Noviembre", Selected = (("11" == mes) ? true : false) });
            list.Add(new SelectListItem { Value = "12", Text = "Diciembre", Selected = (("12" == mes) ? true : false) });

            return list;
        }
    }
}