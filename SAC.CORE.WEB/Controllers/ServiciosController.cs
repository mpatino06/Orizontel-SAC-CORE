using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using SAC.CORE.WEB.Models;
using SAC.CORE.WEB.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Controllers
{
    public class ServiciosController : Controller
    {
        private ServicioServices services;
        private ClientServices clientServices;

        public async Task<ActionResult> Index()
        {
            services = new ServicioServices();
            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await services.GetAfiliacionByIdentificacion(_identificacion);
            return View(result);
        }

        public ActionResult Coordenadas()
        {
            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            return View();
        }

        [HttpPost]
        public ActionResult Coordenadas(string Coordenada1, string Coordenada2)
        {
            //TODO validar coordenadas
            return RedirectToAction("Producto");
        }

        public async Task<ActionResult> Producto()
        {
            services = new ServicioServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var _tiposervicios = await services.GetTipoServicio();
            ViewData["TipoServicio"] = GetTipoServicios(_tiposervicios);

            return View();
        }

        [HttpPost]
        public ActionResult Producto(string IdTipoServicio, string nameProducto)
        {
            services = new ServicioServices();
            clientServices = new ClientServices();

            HttpContext.Session.SetString("NombreServicio", nameProducto);
            HttpContext.Session.SetString("IdServicio", IdTipoServicio);

            return RedirectToAction("Informacion");
        }

        public async Task<ActionResult> Informacion()
        {
            services = new ServicioServices();
            clientServices = new ClientServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            ViewData["TipoServicio"] = HttpContext.Session.GetString("NombreServicio");

            var _tipoidentificacion = await clientServices.GetIdentificacion();

            ViewData["TipoDocumento"] = GetTipoIdentificacion(_tipoidentificacion);

            //var model = new AfiliacionCuenta();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Informacion(AfiliacionCuenta afiliacion)
        {
            clientServices = new ClientServices();

            var result = await clientServices.ValidarAfiliacion(afiliacion.NroCuentaBeneficiario);

            if (result.Identificacion == null)
            {
                var _tipoidentificacion = await clientServices.GetIdentificacion();

                ViewData["TipoDocumento"] = GetTipoIdentificacion(_tipoidentificacion);
                ViewData["TipoServicio"] = HttpContext.Session.GetString("NombreServicio");
                ViewData["NoExiste"] = "true";
            }
            else
            {
                //HttpContext.Session.SetString("MontoMaximo", afiliacion.MontoMaximo);
                //HttpContext.Session.SetString("Alias", afiliacion.Alias);
                HttpContext.Session.SetString("NombreAfiliado", result.NombreUnido);
                HttpContext.Session.SetString("TipoCuenta", result.TipoCuenta);
                HttpContext.Session.SetString("TipoDoc", result.TipoDocumento);
                HttpContext.Session.SetString("IdentificacionAfiliado", result.Identificacion);
                HttpContext.Session.SetString("CuentaAfiliado", result.SecuencialCuenta.ToString());
                HttpContext.Session.SetString("Email", result.Email);
                //ViewData["MontoMax"] = afiliacion.MontoMaximo;
                //ViewData["TipoServicio"] = HttpContext.Session.GetString("NombreServicio");
                return RedirectToAction("Save");
            }

            return View(afiliacion);
        }

        public ActionResult Save()
        {
            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var model = new CuentasClienteAfiliacion
            {
                NombreUnido = HttpContext.Session.GetString("NombreAfiliado"),
                TipoCuenta = HttpContext.Session.GetString("TipoCuenta"),
                TipoDocumento = HttpContext.Session.GetString("TipoDoc"),
                Identificacion = HttpContext.Session.GetString("IdentificacionAfiliado"),
                Email = HttpContext.Session.GetString("Email")
                //SecuencialCuenta = HttpContext.Session.GetInt32("CuentaAfiliado").Value
            };

            //ViewData["Alias"] = HttpContext.Session.GetString("Alias");
            //ViewData["MontoMax"] = HttpContext.Session.GetString("MontoMaximo");
            ViewData["TipoServicio"] = HttpContext.Session.GetString("NombreServicio");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Save(string email, string alias, decimal montomaximo, string Coordenada1, string Coordenada2)
        {
            var items = new Afiliacion
            {
                IdentificacionUsuario = HttpContext.Session.GetString("IdentificacionCliente"),
                IdentificacionCliente = HttpContext.Session.GetString("IdentificacionAfiliado"),
                NombreBeneficiario = HttpContext.Session.GetString("NombreAfiliado"),
                SecuencialCuenta = Convert.ToInt32(HttpContext.Session.GetString("CuentaAfiliado")),
                NombreAfiliacion = alias,
                Fecha = DateTime.Now,
                MontoMaximo = montomaximo,
                EstaActivo = true,
                IdServicio = Convert.ToInt32(HttpContext.Session.GetString("IdServicio")),
                Email = email
            };

            services = new ServicioServices();
            var result = await services.SaveAfiliacion(items);

            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> ProductoEdit(int Id)
        {
            services = new ServicioServices();

            var _identificacion = HttpContext.Session.GetString("IdentificacionCliente");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _horaformato = HttpContext.Session.GetString("UltimoRegistro");

            ViewData["USerName"] = _codigoUsuario;
            ViewData["Section"] = "ServiciosAfiliacion";
            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["HoraFormato"] = _horaformato;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");

            var result = await services.GetAfiliacionById(Id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> ProductoEdit(AfiliacionServicios afiliacion, string submitBtn)
        {
            services = new ServicioServices();

            if (submitBtn == "btnUPD")
            {
                var resultUpd = await services.UpdateAfiliacion(afiliacion);
                if (resultUpd)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["ErrorAfiliacion"] = "true";
                }
            }
            else if (submitBtn == "btnDEL")
            {
                var resultDel = await services.DeleteAfiliacion(afiliacion.IdAfiliciacionCliente);
                if (resultDel)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["ErrorAfiliacion"] = "true";
                }
            }

            return View(afiliacion);
        }

        #region SelectListItem

        public List<SelectListItem> GetTipoServicios(List<Tiposervicio> tiposervicios)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add((new SelectListItem { Value = "0", Text = "Seleccione", Selected = true }));
            foreach (var item in tiposervicios)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre.ToString() });
            }

            return list;
        }

        public List<SelectListItem> GetTipoIdentificacion(List<Tipoidentificacion> identificacion)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in identificacion)
            {
                list.Add(new SelectListItem { Value = item.Secuencial.ToString(), Text = item.Codigo.ToString(), Selected = (item.Codigo == "C") ? true : false });
            }

            return list;
        }

        public List<SelectListItem> GetServicios(List<Servicio> servicios)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add((new SelectListItem { Value = "0", Text = "Seleccione", Selected = true }));
            foreach (var item in servicios)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre.ToString() });
            }

            return list;
        }

        #endregion SelectListItem

        #region Json

        public async Task<JsonResult> GetProductos(int Id)
        {
            services = new ServicioServices();
            List<SelectListItem> list = new List<SelectListItem>();

            var result = await services.GetServicioByTipoServicio(Id);

            list = GetServicios(result);

            return Json(new SelectList(list, "Value", "Text"));
        }

        #endregion Json
    }
}