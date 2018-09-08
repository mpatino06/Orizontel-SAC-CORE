using Microsoft.AspNetCore.Mvc;
using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Services;
using System;
using System.Threading.Tasks;

namespace SAC.CORE.API.Controllers
{
    [Produces("application/json")]
    [Route("sac/Cliente")]
    public class ClienteController : Controller
    {
        private ICliente context;

        public ClienteController()
        {
            context = new ClienteRepository();
        }

        [HttpGet("GetCuentaSocio/{code}")]
        public async Task<IActionResult> GetCuentaSocio([FromRoute] string code)
        {
            var result = await Task.Run(() => context.GetCuentaSocio(code));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpGet("GetMovimientoSaldos/{code}")]
        public IActionResult GetMovimientos([FromRoute] string code)
        {
            var result = context.GetMovimientoSaldos(code);
            if (result == null)
                return NotFound(" Id no Found");

            return Ok(result);
        }

        [HttpGet("GetClienteMora/{user}/{fechaInicial}/{fechaFinal}")]
        public IActionResult GetClienteMora([FromRoute] string user, DateTime fechaInicial, DateTime fechaFinal)
        {
            var result = context.GetClientesMora(user, fechaInicial, fechaFinal);
            if (result == null)
                return NotFound(" Id no Found");

            return Ok(result);
        }

        [HttpGet("GetClienteDetalle/{credito}")]
        public async Task<IActionResult> GetClienteDetalle([FromRoute] string credito)
        {
            var result = await Task.Run(() => context.GetClienteDetalleCredito(credito));
            if (result == null)
                return NotFound(" Id no Found");

            return Ok(result);
        }

        [HttpGet("GetClienteCuentas/{identificacion}")]
        public async Task<IActionResult> GetClienteCuentas([FromRoute] string identificacion)
        {
            var result = await Task.Run(() => context.CuentasCliente(identificacion));
            if (result == null)
                return NotFound("Cliente no tiene Cuentas");

            return Ok(result);
        }

        [HttpGet("GetMovimientos/{secuencial}")]
        public async Task<IActionResult> GetMovimientos([FromRoute] int secuencial)
        {
            var result = await Task.Run(() => context.GetMovimientoCuentas(secuencial));
            if (result == null)
                return NotFound("La Cuenta no tiene Movimientos");

            return Ok(result);
        }

        /// <summary>
        /// API para obtener los movimientos de una cuenta
        /// </summary>
        /// <param name="secuencial">secuencial de cuenta</param>
        /// <param name="mes">mes de movimiento</param>
        /// date>27-06-2018>date>
        /// <author>Miguel Patiño</author>
        /// <returns></returns>
        [HttpGet("GetMovimientosbyMes/{secuencial}/{mes}")]
        public async Task<IActionResult> GetMovimientosbyMes([FromRoute] int secuencial, string mes)
        {
            var result = await Task.Run(() => context.GetMovimientoCuentasByIdAndMonth(secuencial, mes));
            if (result == null)
                return NotFound("La Cuenta no tiene Movimientos");

            return Ok(result);
        }

        /// <summary>
        /// PI para obtener los movimientos de una cuenta en un rando de fecha
        /// </summary>
        /// <param name="secuencial"></param>
        /// <param name="mesIni">Fecha Inicio</param>
        /// <param name="mesFin">Fecha Fin</param>
        /// <returns></returns>
        [HttpGet("GetMovimientosbyRange/{secuencial}/{mesIni}/{mesFin}")]
        public async Task<IActionResult> GetMovimientosbyMes([FromRoute] int secuencial, string mesIni, string mesFin)
        {
            var result = await Task.Run(() => context.GetMovimientoCuentasByIdAndRange(secuencial, mesIni, mesFin));
            if (result == null)
                return NotFound("La Cuenta no tiene Movimientos");

            return Ok(result);
        }

        [HttpGet("GetMovimientosPrestamos/{secuencial}")]
        public async Task<IActionResult> GetMovimientosPrestamos([FromRoute] int secuencial)
        {
            var result = await Task.Run(() => context.GetMovimientosPrestamos(secuencial));
            if (result == null)
                return NotFound("El Prestamo No tienen movimientos");

            return Ok(result);
        }

        [HttpGet("GetCuentasAfiliacionesTercero/{cliente}")]
        public async Task<IActionResult> GetCuentasTerceros([FromRoute] string cliente)
        {
            var result = await Task.Run(() => context.GetAfiliciacionesCuentasTerceros(cliente));
            if (result == null)
                return NotFound("No existen cuentas");

            return Ok(result);
        }

        [HttpGet("GetPrestamosByIdentificacion/{identificacion}")]
        public async Task<IActionResult> GetPrestamosByIdentificacion([FromRoute] string identificacion)
        {
            var result = await Task.Run(() => context.GetPrestamosByIdentificacionCliente(identificacion));
            if (result == null)
                return NotFound("No existen Prestamos");

            return Ok(result);
        }

        [HttpGet("GetTipoIdentificacion")]
        public async Task<IActionResult> GetTipoIdentificacion()
        {
            var result = await Task.Run(() => context.GetAllTipoIdentificacion());
            if (result == null)
                return NotFound("No Existe tipo identificacion");

            return Ok(result);
        }

        [HttpGet("ValidarAfiliacion/{cuenta}")]
        public async Task<IActionResult> ValidarAfiliacion([FromRoute] string cuenta)
        {
            var result = await Task.Run(() => context.ValidateCuentaTerceros(cuenta));
            if (result == null)
                return NotFound("No existen Prestamos");

            return Ok(result);
        }

        [HttpGet("GetCuentas/{identificacion}")]
        public async Task<IActionResult> GetCuentas([FromRoute] string identificacion)
        {
            var result = await Task.Run(() => context.GetClienteCuentas(identificacion));
            if (result == null)
                return NotFound("Cliente no tiene Cuentas");

            return Ok(result);
        }

        [HttpGet("GetDpfById/{identificacion}")]
        public async Task<IActionResult> GetDpfById([FromRoute] int identificacion)
        {
            var result = await Task.Run(() => context.GetDpyById(identificacion));
            if (result == null)
                return NotFound("Cliente no tiene Cuentas");

            return Ok(result);
        }

        [HttpGet("GetListDpf/{identificacion}")]
        public async Task<IActionResult> GetListDpf([FromRoute] string identificacion)
        {
            var result = await Task.Run(() => context.GetMovimientoCuentasDPF(identificacion));
            if (result == null)
                return NotFound("Cliente no tiene Cuentas");

            return Ok(result);
        }

        #region "POST"

        [HttpPost("GetCuentaSocioP/{code}")]
        public async Task<IActionResult> GetCuentaSocioP([FromRoute] string code)
        {
            var result = await Task.Run(() => context.GetCuentaSocio(code));
            if (result == null)
                return NotFound("Product Id no Found");

            return Ok(result);
        }

        [HttpPost("SaveTransferencia")]
        public async Task<IActionResult> PostSaveTransferencia([FromBody] TransferenciaTercerosCuentas model)
        {
            bool result = await Task.Run(() => context.AddTransferencia(model));
            if (!result)
                return NotFound("Transferencia no Save");

            return Ok(result);
        }

        [HttpPost("SaveDPF")]
        public async Task<IActionResult> PostSaveDPF([FromBody] DepositoPlazoFijo model)
        {
            bool result = await Task.Run(() => context.AddDPF(model));
            if (!result)
                return NotFound("DPF no Save");

            return Ok(result);
        }

        #endregion "POST"
    }
}