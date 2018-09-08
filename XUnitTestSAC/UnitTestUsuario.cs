using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.Controllers;
using SAC.CORE.API.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestSAC
{
    public class UnitTestUsuario
    {
        [Fact]
        public void Test1()
        {
            UsuarioController controller = new UsuarioController();
            var result = controller.GetByCode("GMSISALEMA");
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<UsuarioComplementoExtend>(
                viewResult.ViewData.Model);

            Assert.Equal(2, model.Secuencialpersona);
            //string viewResult = ((UsuarioComplementoExtend)((ObjectResult)result).Value).Secuencialoficina.ToString();

            //Assert.IsType<ViewResult>(result);            

            //Assert.NotNull(actionresult);

            //UsuarioComplementoExtend result = actionresult as UsuarioComplementoExtend;


            //Assert.NotNull(((UsuarioComplementoExtend)actionresult).Nombre);
            //Assert.Equal("200", result.Codigousuario);
        }
    }
}
