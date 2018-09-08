namespace SAC.CORE.API.Models
{
    public partial class DepositocomponentePlazo
    {
        public int Secuencial { get; set; }
        public int Secuencialdeposito { get; set; }
        public int Secuencialcomponenteplazo { get; set; }
        public string Codigotipocancelacion { get; set; }
        public decimal Saldo { get; set; }
        public int Numeroverificador { get; set; }
    }
}