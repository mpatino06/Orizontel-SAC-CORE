using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class TransferenciaTercerosCuentas
    {
        public string IdentificacionCliente { get; set; }
        public int SecuencialCuentaCliente { get; set; }
        public int SecuencialCuentaAfiliado { get; set; }
        public List<ClienteCuentas> CuentasCliente { get; set; }
        public List<CuentasClienteAfiliacion> AfiliacionCliente { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public string Coordenada1 { get; set; }
        public string Coordenada2 { get; set; }
        public int TipoTransferencia { get; set; }  //1. Terceros 2. Propias
    }
}