using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Services;
using System.Threading.Tasks;

namespace SAC.CORE.API.Controllers
{
    [Produces("application/json")]
    [Route("sac/Servicio")]
    public class ServicioController : Controller
    {
        private IServicio context;

        public ServicioController()
        {
            context = new ServicioRepository();
        }

        [HttpGet("GetTipoServicio")]
        public async Task<IActionResult> GetTipoServicio()
        {
            var result = await Task.Run(() => context.GetServicios());
            if (result == null)
                return NotFound("Servcios no Found");

            return Ok(result);
        }

        [HttpGet("GetServicioByTipoServicio/{Id}")]
        public async Task<IActionResult> GetServicioByTipoServicio([FromRoute] int Id)
        {
            var result = await Task.Run(() => context.GetServicioByIdTipoServicio(Id));
            if (result == null)
                return NotFound("services Id no Found");

            return Ok(result);
        }

        [HttpGet("GetAfiliacion/{Identificacion}")]
        public async Task<IActionResult> GetAfiliacion([FromRoute] string Identificacion)
        {
            var result = await Task.Run(() => context.GetAllAfiliacion(Identificacion));
            if (result == null)
                return NotFound("services Id no Found");

            return Ok(result);
        }

        [HttpGet("GetAfiliacionById/{Id}")]
        public async Task<IActionResult> GetAfiliacionById([FromRoute] int Id)
        {
            var result = await Task.Run(() => context.GetAfiliacionById(Id));
            if (result == null)
                return NotFound("Id no Found");

            return Ok(result);
        }

        [HttpGet("DeleteAfiliacion/{Id}")]
        public async Task<IActionResult> DeleteAfiliacion([FromRoute] int Id)
        {
            var result = await Task.Run(() => context.DeleteAfiliacion(Id));
            if (!result)
                return NotFound("Afiliacion not Delete");

            return Ok(result);
        }

        [HttpGet("GetPlazoFijoPeriodo")]
        public async Task<IActionResult> GetPlazoFijoPeriodo()
        {
            var result = await Task.Run(() => context.GetPlazoPeriodo());
            if (result == null)
                return NotFound("Plazo Periodo Not Found");

            return Ok(result);
        }

        [HttpGet("GetPlazoFijo/{plazo}/{Monto}")]
        public async Task<IActionResult> GetPlazoFijo([FromRoute] int plazo, decimal Monto)
        {
            var result = await Task.Run(() => context.GetPlazoFijoTazas(plazo, Monto));
            if (result == null)
                return NotFound("Afiliacion not Delete");

            return Ok(result);
        }

        [HttpPost("SaveAfiliacion")]
        public async Task<IActionResult> SaveAfiliacion([FromBody] Afiliacion model)
        {
            int result = await Task.Run(() => context.SaveAfiliacionCliente(model));
            if (result == 0)
                return NotFound("Afiliacion no Save");

            return Ok(result);
        }

        [HttpPost("UpdateAfiliacion")]
        public async Task<IActionResult> UpdateAfiliacion([FromBody] AfiliacionServicios model)
        {
            bool result = await Task.Run(() => context.UpdateAfiliacion(model));
            if (!result)
                return NotFound("Afiliacion no Update");

            return Ok(result);
        }
    }
}