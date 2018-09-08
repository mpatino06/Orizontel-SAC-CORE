using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Models;
using SAC.CORE.API.Services;
//using SAC.CORE.API.Models;

namespace SAC.CORE.API.Controllers
{
    [Route("SAC/[controller]")]
    public class ValuesController : Controller
    {

        FBS_SacAmbatoContext context = new FBS_SacAmbatoContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IUsuario userContext = new UsuarioRepository();

            var result = userContext.GetUserByCode("00001");
           // var result = context.Usuario.ToList();

            return new string[] { result.Nombre , "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
