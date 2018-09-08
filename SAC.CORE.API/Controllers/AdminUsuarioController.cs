using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAC.CORE.API.Controllers
{
    [Produces("application/json")]
    [Route("sac/AdminUsuario")]
    public class AdminUsuarioController : Controller
    {
        private IAdminUsuario context;

        public AdminUsuarioController()
        {
            context = new AdminUsuarioRepository();
        }

        [HttpGet("GetUsuario/{user}/{pass}/{guarda}")]
        public async Task<IActionResult> GetUsuario(string user, string pass, bool guarda)
        {
            var result = await Task.Run(() => context.GetUsuario(user, pass, guarda));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpGet("ValidateUser/{codigo}/{user}/{fecha}")]
        public async Task<IActionResult> ValidateUSer(string codigo, string user, string fecha)
        {
            DateTime _nac = Convert.ToDateTime(fecha);

            var result = await Task.Run(() => context.ValidateUser(codigo, user, _nac));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpPost("PostUsuario")]
        public async Task<IActionResult> PostUsuario([FromBody] AdminUsuario usuario)
        {
            AdminUsuario _usuario = new AdminUsuario();
            if (usuario != null)
            {
                _usuario = await Task.Run(() => context.SaveUsuario(usuario));
                if (_usuario == null)
                    return NotFound("No se guardo el usuario");
            }

            return Ok(_usuario);
        }

        //[HttpPost("SavePreguntasUsuario")]
        //public async Task<IActionResult> SavePreguntasUsuario([FromBody] List<Usuariopregunta> usuario)
        //{
        //    bool result =false;
        //    if (usuario != null)
        //    {
        //        result = await Task.Run(() => context.SavePreguntaUsuario(usuario));
        //        if (result == false)
        //            return NotFound("No se guardaron las preguntas");
        //    }

        //    return Ok(result);
        //}
    }
}