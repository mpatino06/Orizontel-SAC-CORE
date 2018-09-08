using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAC.CORE.API.Controllers;
using SAC.CORE.API.Models;
using SAC.CORE.API.Services;
using SAC.CORE.API.Interface;

namespace UnitTestSAC
{
    [TestClass]
    public class UnitTestUsuario
    {
        [TestMethod]
        public void TestMethodGetUserByCode()
        {
            IUsuario controller = new UsuarioRepository();
            var result = controller.GetUserByCode("GMSISALEMA");

            Assert.AreEqual("GMSISALEMA", result.Codigousuario);
        }
    }
}
