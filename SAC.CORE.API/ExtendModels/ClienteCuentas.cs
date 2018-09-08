namespace SAC.CORE.API.ExtendModels
{
    public class ClienteCuentas
    {
        public string Codigo { get; set; }
        public string CodigoTipocuenta { get; set; }
        public string codigoProductoVista { get; set; }
        public int SecuencialCuentaMaestro { get; set; }
        public string NombreTipoCuenta { get; set; }
        public string CodigoEstadoCuenta { get; set; }
        public string NombreEstadoCuenta { get; set; }
        public int NumeroLibreta { get; set; }
        public int SecuencialCuentaCliente { get; set; }
        public bool UsaLibreta { get; set; }
        public bool UsaChequera { get; set; }
        public int NumeroLineaLibreta { get; set; }
        public bool TieneSeguro { get; set; }
        public string Identificacion { get; set; }
        public string NombreUnido { get; set; }
        public decimal SaldoCuenta { get; set; }
        public int SecuencialCliente { get; set; }
    }
}