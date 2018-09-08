namespace SAC.CORE.API.Models
{
    public partial class TipoPrestamo
    {
        public TipoPrestamo()
        {
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public int Secuencialempresa { get; set; }
        public int Plazominimo { get; set; }
        public int Plazomaximo { get; set; }
        public decimal Montominimo { get; set; }
        public decimal Montomaximo { get; set; }
        public decimal Calificacionminimasolsobrediez { get; set; }
        public bool Escobrohorizontal { get; set; }
        public int Numerominimodeudores { get; set; }
        public int Numeromaximodeudores { get; set; }
        public bool Frecuenciarestringida { get; set; }
        public string Nivelcontable { get; set; }
        public int Diasminimoreajuste { get; set; }
        public bool Esoperativo { get; set; }
        public string Nombremetodoobtienecalifgrupo { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
        public int? Numerodiasmoraavalidar { get; set; }
        public bool Esparabacktoback { get; set; }
        public bool Aceptalineacredito { get; set; }
        public bool Aceptacuotasdegracia { get; set; }
    }
}