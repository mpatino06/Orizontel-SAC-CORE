using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Services;
using System.Threading.Tasks;

namespace SAC.CORE.API.Controllers
{
    [Produces("application/json")]
    [Route("sac/Solicitud")]
    public class SolicitudController : Controller
    {
        private ISolicitud services;

        public SolicitudController()
        {
            services = new SolicitudRepository();
        }

        [HttpGet("GetInfoSolicitud")]
        public async Task<IActionResult> GetInfoSolicitud()
        {
            var result = await Task.Run(() => services.GetInfosolicitudPrestamo());
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpPost("SaveSolicitudPrestamo")]
        public async Task<IActionResult> SaveSolicitudPrestamo([FromBody] SolicitudPrestamo model)
        {
            var result = await Task.Run(() => services.SaveSolicitud(model));
            if (result == null)
                return NotFound("Transferencia no Save");

            return Ok(result);
        }

        [HttpGet("GetTipoPrestamo/{nombre}")]
        public async Task<IActionResult> GetTipoPrestamo([FromRoute] string nombre)
        {
            var result = await Task.Run(() => services.GetByNombre(nombre));
            if (result == null)
                return NotFound("Prestamo name no Found");

            return Ok(result);
        }

        [HttpGet("GetSolicitudbyId/{identificacion}")]
        public async Task<IActionResult> GetSolicitudbyId([FromRoute] string identificacion)
        {
            var result = await Task.Run(() => services.GetSolicitudByID(identificacion));
            if (result == null)
                return NotFound("Prestamo name no Found");

            return Ok(result);
        }
    }
}