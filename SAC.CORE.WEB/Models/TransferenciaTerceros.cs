namespace SAC.CORE.WEB.Models
{
    public class TransferenciaTerceros
    {
        public string IdentificacionCliente { get; set; }
        public int SecuencialCuentaCliente { get; set; }
        public int SecuencialCuentaAfiliado { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public string Coordenada1 { get; set; }
        public string Coordenada2 { get; set; }
        public int TipoTransferencia { get; set; }  //1. Terceros 2. Propias
    }
}