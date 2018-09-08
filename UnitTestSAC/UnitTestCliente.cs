using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestSAC
{
    [TestClass]
    public class UnitTestCliente
    {
        [TestMethod]
        public void TestMethodGetCuentaSocio()
        {
            ICliente controller = new ClienteRepository();
            var result = controller.GetCuentaSocio("1704829777");

            Assert.AreEqual("14954", result._Personas.SECUENCIAL.ToString());
        }

        [TestMethod]
        public void TestMethodGetMovimientoSaldos()
        {
            ICliente controller = new ClienteRepository();
            var result = controller.GetMovimientoSaldos("1704829777");

            Assert.AreEqual("14954", result._PERSONAS.SECUENCIAL.ToString());
        }

        [TestMethod]
        public void TestMethodGetClienteDetalleCredito()
        {
            ICliente controller = new ClienteRepository();
            var result = controller.GetClienteDetalleCredito("43288-6301");

            Assert.AreEqual("SMASABANDA", result._PRESTAMOS.CODIGOUSUARIOOFICIAL);
        }
        
    }
}
