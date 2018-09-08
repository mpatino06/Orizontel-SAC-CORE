namespace SAC.CORE.API.Models
{
    public partial class MovimientodepositocompPlazo
    {
        public int Secuencial { get; set; }
        public int Secuencialmovimientodetalle { get; set; }
        public int Secuencialdeposito { get; set; }
        public int Secuencialcomponenteplazo { get; set; }
        public string Codigotipomovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}