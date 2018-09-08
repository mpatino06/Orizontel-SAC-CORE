using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Models;
using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Interface
{
    public interface ICliente
    {
        CuentaSocio GetCuentaSocio(string code);

        ClienteMovimientoSaldos GetMovimientoSaldos(string code);

        List<PrestamoMaestros> GetClientesMora(string usuario, DateTime fechaInicial, DateTime fechaFinal);

        ClienteDetalleCredito GetClienteDetalleCredito(string credito);

        ClienteConsolidado CuentasCliente(string identificacion);

        List<ClienteCuentaMovimientos> GetMovimientoCuentas(int secuencial);

        List<PrestamosMovimientos> GetMovimientosPrestamos(int secuencialPrestamo);

        TransferenciaTercerosCuentas GetAfiliciacionesCuentasTerceros(string cliente);

        bool AddTransferencia(TransferenciaTercerosCuentas transferencia);

        List<PrestamoMaestros> GetPrestamosByIdentificacionCliente(string identificacion);

        List<Tipoidentificacion> GetAllTipoIdentificacion();

        CuentasClienteAfiliacion ValidateCuentaTerceros(string cuenta);

        List<ClienteCuentas> GetClienteCuentas(string identificacion);

        bool AddDPF(DepositoPlazoFijo plazofijo);

        DepositoPlazoFijo GetDpyById(int secuencial);

        List<Depositomaestro> GetMovimientoCuentasDPF(string identificacion);

        List<ClienteCuentaMovimientos> GetMovimientoCuentasByIdAndMonth(int secuencial, string mes);

        List<ClienteCuentaMovimientos> GetMovimientoCuentasByIdAndRange(int secuencial, string mesIni, string mesFin);
    }
}