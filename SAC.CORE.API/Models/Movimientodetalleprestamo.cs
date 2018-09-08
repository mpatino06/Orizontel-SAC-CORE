namespace SAC.CORE.API.Models
{
    public class Movimientodetalleprestamo
    {
        public Movimientodetalleprestamo()
        {
        }

        public int Secuencialmovimientodetalle { get; set; }
        public int Secuencialprestamo { get; set; }
        public decimal Saldoprestamo { get; set; }
        public string Codigoestadoprestamo { get; set; }
    }
}