using System;

namespace SAC.CORE.API.ExtendModels
{
    public class ClienteCuentaMovimientos
    {
        public string CodigoTipocuenta { get; set; }
        public string CodigoCuentaMaestro { get; set; }
        public string CodigoUsuario { get; set; }
        public int NumeroCliente { get; set; }
        public string Identificacion { get; set; }
        public string NombreUnido { get; set; }
        public decimal Valor { get; set; }
        public string NombreTransacion { get; set; }
        public DateTime Fecha { get; set; }
        public int SecuencialMovimiento { get; set; }
        public int SecuencialMovimientoDetalle { get; set; }
        public int Secuencialtransaccion { get; set; }
        public string Documento { get; set; }
        public decimal SaldoCuenta { get; set; }
        public string CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public string NombreTipoCuenta { get; set; }
    }
}