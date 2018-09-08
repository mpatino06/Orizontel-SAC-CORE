namespace SAC.CORE.API.Models
{
    public partial class Movimientodetalle
    {
        public int Secuencial { get; set; }
        public int Secuencialmovimiento { get; set; }
        public int Secuencialtransaccion { get; set; }
        public int Secuencialmoneda { get; set; }
        public decimal Valor { get; set; }
        public int Secuencialoficinaafectada { get; set; }
    }
}