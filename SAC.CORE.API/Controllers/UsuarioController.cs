using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Services;
using System.Threading.Tasks;

namespace SAC.CORE.API.Controllers
{
    [Produces("application/json")]
    [Route("sac/Usuario")]
    public class UsuarioController : Controller
    {
        private IUsuario context;

        public UsuarioController()
        {
            context = new UsuarioRepository();
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {
            //var result = await context.GetUserByCode(code);
            var result = await Task.Run(() => context.GetUserByCode(code));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpGet("GetByIdentificacion/{code}")]
        public async Task<IActionResult> GetByIdentificacion([FromRoute] string code)
        {
            //var result = await context.GetUserByCode(code);
            var result = await Task.Run(() => context.GetUserByIdentificacion(code));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpPost("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario([FromBody] AdminUsuario usuario)
        {
            var result = await Task.Run(() => context.Update(usuario));
            if (!result)
                return NotFound("Product NOT Update");

            return Ok(result);
        }

        [HttpGet("GetByNameAndIdentificacion/{code}")]
        public async Task<IActionResult> GetByNameAndIdentificacion([FromRoute] string code)
        {
            var result = await Task.Run(() => context.GetUserByNameAndIdentificacion(code));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpGet("GetAllPreguntas")]
        public async Task<IActionResult> GetAllPreguntas()
        {
            //var result = await context.GetUserByCode(code);
            var result = await Task.Run(() => context.GetAllPreguntas());
            if (result == null)
                return NotFound("No se encontraron preguntas");

            return Ok(result);
        }
    }
}