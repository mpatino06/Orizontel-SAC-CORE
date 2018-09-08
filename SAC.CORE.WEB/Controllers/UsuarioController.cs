using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.Models;
using SAC.CORE.WEB.Services;
using System.Threading.Tasks;

namespace SAC.CORE.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private UserServices userServices;

        public async Task<IActionResult> Index()
        {
            //ViewData["Section"] = "Usuario";
            //return View();

            userServices = new UserServices();

            var ID = HttpContext.Session.GetString("USerName1");
            var _id = HttpContext.Session.GetString("IdentificacionCliente").ToString();
            var _rutaImagen = HttpContext.Session.GetString("RutaImagen");
            var _codigoUsuario = HttpContext.Session.GetString("USerName1");

            ViewData["RutaImagen"] = _rutaImagen;
            ViewData["NombreUnido"] = HttpContext.Session.GetString("NombreCompleto");
            ViewData["USerName"] = _codigoUsuario;

            var items = await userServices.GetUser(_id);

            if (items._Persona == null)
            {
                ViewBag.ExisteUsuario = "False";
                return View();
            }

            ViewData["Section"] = "Usuario";
            return View("Info", items);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string selImagen, SAC.CORE.API.ExtendModels.PersonaDetalle persona)
        {
            userServices = new UserServices();

            var _id = HttpContext.Session.GetString("IdentificacionCliente").ToString();

            persona._AdminUsuario.Identificacion = _id;
            persona._AdminUsuario.Imagen = selImagen;
            var items = await userServices.UpdateUser(persona._AdminUsuario);

            if (!items)
            {
                ViewBag.ExisteUsuario = "False";
                return View();
            }

            //ViewData["Section"] = "Usuario";
            return RedirectToAction("Index", "register");
        }

        [HttpGet]
        public ActionResult List()
        {
            //clientServices = new ClientServices();
            //var items = await clientServices.GetCuentaSocio("1805279047");
            var model = TempData["list"] as UsuarioComplementoExtend;

            return View(model);
        }
    }
}