using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Models;
using SAC.CORE.WEB.Infrastructure;
using SAC.CORE.WEB.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Controllers
{
    public class SolicitudController : Controller
    {
        private SolictudServices solcitudServices;
        private ClientServices clientServices;
        private UserServices userServices;
        private NumLetras numletras;

        public ActionResult P2()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            solcitudServices = new SolictudServices();
            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "Solicitudes";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await solcitudServices.GetSolicitudByIdentificacion(_identificacion);
            ViewData["ListDpf"] = await solcitudServices.GetListDpf(_identificacion);
            return View(result);
        }

        public async Task<ActionResult> SolicitudPrestamo()
        {
            solcitudServices = new SolictudServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "Simulador";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await solcitudServices.GetDataSolicitudPrestamo();

            ViewData["TipoPrestamo"] = solcitudServices.GetTipoPrestamos(result.prestamos);
            ViewData["Amortizacion"] = solcitudServices.GetAmortizacion(result.amortizacion);

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SolicitudPrestamo(SolicitudPrestamo solicitud)
        {
            solcitudServices = new SolictudServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "Simulador";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            solicitud.NumerosocioMigra = _identificacion;

            //TODO HiddenFor not working
            solicitud.SecuencialOficina = "6813";
            solicitud.CodigoProductoCartera = "5";
            solicitud.SecuencialSegmentoInterno = 114;
            solicitud.CodigoSubcalificacionContable = "401";
            solicitud.CobraporRol = false;
            solicitud.CodigoOrigenRecurso = "P";
            //

            var result = await solcitudServices.SaveSolicitudPrestamo(solicitud);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Dpf()
        {
            solcitudServices = new SolictudServices();
            clientServices = new ClientServices();
            userServices = new UserServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "Dpf";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            ViewData["IdentificacionCliente"] = _identificacion;

            var result = await clientServices.GetCuentas(_identificacion);
            var cuentas = result.FirstOrDefault(a => a.CodigoTipocuenta == "2"); //AHORROS A LA VISTA

            //var periodos = await solcitudServices.GetPeriodoPlazoFijo();
            //ViewData["PeriodoPF"] = solcitudServices.GetPeriodoPF(periodos);

            var items = await userServices.GetUser(_identificacion);
            string telefonos = string.Empty;

            if (cuentas != null)
            {
                ViewData["SecuencialCliente"] = cuentas.SecuencialCliente;
                ViewData["MontoMaxCuenta"] = cuentas.SaldoCuenta;
                ViewData["TipoCuentacliente"] = 2;
                ViewData["SecuencialCuenta"] = cuentas.SecuencialCuentaMaestro;
                ViewData["DireccionCliente"] = items._Persona.REFERENCIADOMICILIARIA;
                ViewData["CodigoCliente"] = items._Persona.IDENTIFICACION;

                foreach (var x in items._TelefonoPersonas)
                {
                    telefonos += x.NUMEROTELEFONO + " | ";
                }

                telefonos = telefonos.Trim();

                ViewData["TelefonoCliente"] = (telefonos.Length > 0) ? telefonos.Remove(telefonos.Length - 1) : "No Posee Telefonos";
            }
            else
            {
                ViewData["MontoMaxCuenta"] = 0;
                ViewData["TipoCuentacliente"] = 0;
                // ViewData["PeriodoPF"] = new List<SelectListItem>();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Dpf(int SecuenciaCuenta, decimal Monto, decimal TasaInteres, int PlazoDias, int SecuencialCliente, string BenIdentificacion, string BenNombre, string BenParentesco, string BenDireccion, string BenTelefono)
        {
            clientServices = new ClientServices();

            DepositoPlazoFijo dpf = new DepositoPlazoFijo
            {
                Codigotipodeposito = "001",
                Codigoproductoplazo = "4",
                Monto = Monto,
                Tasa = TasaInteres,
                Variaciontasa = 1,
                Plazoendias = PlazoDias,
                Pagoperiodicointeres = false,
                Fechacreacion = DateTime.Now,
                Codigoestadodeposito = "A",
                Secuencialmoneda = 1,
                Secuencialoficina = 6831,
                Codigousuario = "ADMIN",
                Fechamaquinacreacion = DateTime.Now,
                Fechacorte = DateTime.Now,
                NumeroverificadorDepositoMaestro = 8,
                Secuencialempresa = 3,
                SecuencialCliente = SecuencialCliente,
                EsPrincipal = true,
                EsConjunto = true,
                EstaActivo = true,
                NumeroverificadorDepositoCliente = 1,
                Secuencialcomponenteplazo = 31,
                Codigotipocancelacion = "N",
                SaldoDepositoCompPlazo = Monto,
                NumeroverificadorCompPlazo = 2,
                SecuencialCuenta = SecuenciaCuenta,
                NumeroverificadorDepositoCompPlazoRangoTemp = 2,
                Beneficiario = new Depositobeneficiario
                {
                    Beneficiario = BenNombre,
                    Parentesco = BenParentesco,
                    Direccion = BenDireccion,
                    Telefono = BenTelefono,
                    Numeroverificador = 1,
                    Esconjunto = false,
                    Identificacionbeneficiario = BenIdentificacion
                }
            };

            //var transferencia = new SAC.CORE.WEB.Models.TransferenciaTerceros()
            //{
            //    IdentificacionCliente = HttpContext.Session.GetString("IdentificacionCliente"),
            //    SecuencialCuentaCliente = SecuenciaCuenta,
            //    Monto = Monto,
            //    Concepto = "Inversion DPF"
            //};

            bool result = await clientServices.SaveDPF(dpf);

            if (result)
            {
                return RedirectToAction("Consolidado", "Client");
            }

            return View();
        }

        public ActionResult Print(string tit, string ben, string cap, string fecE, string fecV, string fecC, string dir, string tel, string soc, string capn, string interes, string tot, string ide, string plaz)
        {
            ViewData["NombreTitular"] = tit;
            ViewData["NombreBeneficiario"] = ben.ToUpper();
            ViewData["MontoLetras"] = cap;
            ViewData["FecEmision"] = fecE;
            ViewData["FecVencimiento"] = fecV;
            ViewData["FecCancelacion"] = fecC;
            ViewData["Direccion"] = dir;
            ViewData["Telefono"] = tel;
            ViewData["Socio"] = soc;
            ViewData["Capital"] = capn;
            ViewData["Interes"] = interes;
            ViewData["Total"] = tot;
            ViewData["Identificacion"] = ide;
            ViewData["Plazo"] = plaz;
            return View();
        }

        public async Task<ActionResult> PrintDoc(int secuencial)
        {
            clientServices = new ClientServices();
            userServices = new UserServices();
            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");

            numletras = new NumLetras();

            numletras.MascaraSalidaDecimal = "00/100 DOLARES";
            numletras.SeparadorDecimalSalida = "con";
            numletras.ConvertirDecimales = true;
            string smonto = "";
            string telefonos = string.Empty;
            decimal TasaInt = 0;

            var items = await userServices.GetUser(_identificacion);
            foreach (var x in items._TelefonoPersonas)
            {
                telefonos += x.NUMEROTELEFONO + " | ";
            }

            telefonos = telefonos.Trim();

            var result = await clientServices.GetByPdf(secuencial);

            if (result != null)
            {
                smonto = numletras.ToCustomCardinal(result.Monto).ToUpper();
                TasaInt = (result.Monto * result.Tasa) / 100;
            }
            ViewData["NombreTitular"] = items._Persona.NOMBREUNIDO;
            ViewData["NombreBeneficiario"] = result.Beneficiario.Beneficiario.ToUpper();
            ViewData["MontoLetras"] = smonto + " DOLARES";
            ViewData["FecEmision"] = result.Fechacreacion.ToString("dd/MM/yyyy");
            ViewData["FecVencimiento"] = result.Fechacreacion.AddDays(result.Plazoendias).ToString("dd/MM/yyyy");
            ViewData["FecCancelacion"] = result.Fechacreacion.AddDays(result.Plazoendias + 1).ToString("dd/MM/yyyy");
            ViewData["Direccion"] = items._Persona.REFERENCIADOMICILIARIA;
            ViewData["Telefono"] = (telefonos.Length > 0) ? telefonos.Remove(telefonos.Length - 1) : "No Posee Telefonos";
            ViewData["Socio"] = items._Persona.NOMBREUNIDO;
            ViewData["Capital"] = result.Monto;
            ViewData["Interes"] = result.Tasa;
            ViewData["Total"] = result.Monto + TasaInt;
            ViewData["Identificacion"] = _identificacion;
            ViewData["Plazo"] = result.Plazoendias;
            return View("Print");
        }

        #region JSON

        public async Task<JsonResult> GetPrestamos(string name)
        {
            solcitudServices = new SolictudServices();
            var result = await solcitudServices.GetTipoPrestamo(name);
            return Json(result);
        }

        public async Task<JsonResult> GetPlazoFijoPorcentaje(int Plazo, decimal Monto)
        {
            numletras = new NumLetras();

            numletras.MascaraSalidaDecimal = "00/100 DOLARES";
            numletras.SeparadorDecimalSalida = "con";
            numletras.ConvertirDecimales = true;

            var smonto = numletras.ToCustomCardinal(Monto).ToUpper();

            solcitudServices = new SolictudServices();
            var result = await solcitudServices.GetPlazoFijoByMonto(Plazo, Monto);
            result.MontoLetras = smonto + " DOLARES";
            return Json(result);
        }

        #endregion JSON
    }
}