namespace SAC.CORE.API.Models
{
    public partial class SolicitudmaestroPrestamo
    {
        public int Secuencialsolicitud { get; set; }
        public string Codigotipoprestamo { get; set; }
        public string Codigoproductocartera { get; set; }
        public int Secuencialsegmentointerno { get; set; }
        public int Secuencialcondiciontablaamortz { get; set; }
        public string Codigosubcalificacioncontable { get; set; }
        public int Frecuenciapago { get; set; }
        public int Numerocuotas { get; set; }
        public bool Cobraporrol { get; set; }
        public string Codigoorigenrecurso { get; set; }
    }
}