using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAC.CORE.WEB.Models;
using System.Diagnostics;

namespace SAC.CORE.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["USerName"] = HttpContext.Session.GetString("USerName1");

            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}