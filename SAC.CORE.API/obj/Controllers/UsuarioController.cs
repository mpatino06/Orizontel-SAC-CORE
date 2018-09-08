using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Models;
using SAC.CORE.API.Services;

namespace SAC.CORE.API.Controllers
{
    //[Produces("application/json")]
    [Route("SAC/[controller]")]
    public class UsuarioController : Controller
    {


        IUsuario userContext;

        //public UsuarioController(UsuarioRepository usuario)
        //{
        //    _userContext = usuario;
        //}


        //[HttpGet("GetByCode/{code}")]
        //public UsuarioComplementoExtend GetByCode([FromRoute] string code)
        //{
        //    userContext = new UsuarioRepository();
        //    return userContext.GetUserByCode(code);
        //}

        [HttpGet("GetByCode/{code}")]
        public IActionResult GetByCode([FromRoute] string code)
        {
            userContext = new UsuarioRepository();
            var model = userContext.GetUserByCode(code);
            //if (model == null)
            //    return NotFound("Error");
            return Ok(model.Emailinterno);
        }



    }
}