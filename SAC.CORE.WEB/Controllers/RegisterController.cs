using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.WEB.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Controllers
{
    //[RequireHttps]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string username, string password)
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();
            var result = await _services.GetUser(username, password, true);
            if (result.Id > 0)
            {
                //Variables de Session
                var horaFormato = result.UltimoIgreso.ToString("dddd d MMMM") + ", hora " + result.UltimoIgreso.ToString("HH:mm tt");

                HttpContext.Session.SetString("IdUsuario", result.Id.ToString());
                HttpContext.Session.SetString("USerName1", result.Codigo);
                HttpContext.Session.SetString("IdentificacionCliente", result.Identificacion);
                HttpContext.Session.SetString("RutaImagen", result.RutaImagen);
                HttpContext.Session.SetString("UltimoRegistro", horaFormato);

                return RedirectToAction("Consolidado", "Client");
            }
            else
            {
                ViewBag.Error = "True";
                return View();
            }
        }

        public async Task<ActionResult> Info()
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();

            var preguntas = await _services.GetAllPreguntas();

            ViewData["q1"] = _services.GetPreguntas(preguntas);
            ViewData["q2"] = ViewData["q1"];

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Info(string username, string identificacion, string password, string texto, string selImagen, int Question1, string r1, int Question2, string r2)
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();
            List<Usuariopregunta> pregunta = new List<Usuariopregunta>();

            pregunta.Add(new Usuariopregunta { Idusuario = 0, Idpregunta = Question1, Respuesta = r1 });
            pregunta.Add(new Usuariopregunta { Idusuario = 0, Idpregunta = Question2, Respuesta = r2 });

            AdminUsuario adminUsuario = new AdminUsuario
            {
                Identificacion = identificacion,
                Codigo = username,
                Clave = password,
                Imagen = selImagen,
                TextoImagen = texto,
                preguntas = pregunta
            };                
         
            var result = await _services.Save(adminUsuario);
            if (result.Message == null)
            {
                var horaFormato = DateTime.Now.ToString("dddd d MMMM") + ", hora " + DateTime.Now.ToString("HH:mm tt");

                HttpContext.Session.SetString("USerName1", result.Codigo);
                HttpContext.Session.SetString("IdentificacionCliente", identificacion);
                HttpContext.Session.SetString("RutaImagen", result.RutaImagen);
                HttpContext.Session.SetString("UltimoRegistro", horaFormato);

                return RedirectToAction("Consolidado", "Client");
            }
            else
            {
                ViewBag.ErrorRegister = "True";
                ViewBag.MessageRegister = result.Message;
                return View();
            }
        }


        public ActionResult Cambio()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cambio(string username, string password, string texto, string selImagen)
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();

            AdminUsuario adminUsuario = new AdminUsuario
            {
                Identificacion = username,
                Clave = password,
                Imagen = selImagen,
                TextoImagen = texto
            };

            var result = await _services.Update(adminUsuario);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
            //if (result.Message == null)
            //{
            //    var horaFormato = DateTime.Now.ToString("dddd d MMMM") + ", hora " + DateTime.Now.ToString("HH:mm tt");

            //    HttpContext.Session.SetString("USerName1", result.Codigo);
            //    HttpContext.Session.SetString("IdentificacionCliente", identificacion);
            //    HttpContext.Session.SetString("RutaImagen", result.RutaImagen);
            //    HttpContext.Session.SetString("UltimoRegistro", horaFormato);

            //    return RedirectToAction("Consolidado", "Client");
            //}
            //else
            //{
            //    ViewBag.ErrorRegister = "True";
            //    ViewBag.MessageRegister = result.Message;
            //    return View();
            //}
        }

        #region JSON

        public async Task<JsonResult> ValidateUser(string codigo, string identificacion, DateTime fecha)
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();
            var result = await Task.Run(async () => await _services.GetValidateUser(codigo, identificacion, fecha));
            return Json(result);
        }

        public async Task<JsonResult> GetUserByNombreAndIdentificacion(string user)
        {
            AdminUsuarioServices _services = new AdminUsuarioServices();
            var result = await Task.Run(async () => await _services.GetUserByNameAndIdenticacion(user));
            return Json(result);
        }

        #endregion JSON
    }
}