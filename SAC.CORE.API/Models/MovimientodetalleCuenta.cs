namespace SAC.CORE.API.Models
{
    public partial class MovimientodetalleCuenta
    {
        public int Secuencialmovimientodetalle { get; set; }
        public int Secuencialcuenta { get; set; }
        public decimal Saldocuenta { get; set; }
        public string Codigoestadocuenta { get; set; }
    }
}