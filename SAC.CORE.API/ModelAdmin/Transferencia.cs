using System;

namespace SAC.CORE.API.ModelAdmin
{
    public class Transferencia
    {
        public int IdTransferencia { get; set; }
        public int IdAfiliacioncliente { get; set; }
        public int SecuencialCuentacliente { get; set; }
        public DateTime Fecha { get; set; }
        public int SecuencialTransaccion { get; set; }
        public decimal Valor { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public decimal SaldoCuenta { get; set; }
        public int SecuencialMovimiento { get; set; }
    }
}