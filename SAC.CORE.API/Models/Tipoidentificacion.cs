namespace SAC.CORE.API.Models
{
    public partial class Tipoidentificacion
    {
        public int Secuencial { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Parapersonanatural { get; set; }
        public int Numerominimorepresentantes { get; set; }
        public int Numerominimoreferenciaspersonas { get; set; }
        public int Numerominimoreferenciasbancari { get; set; }
        public int Numerominimoreferenciascomerci { get; set; }
        public bool Estaactiva { get; set; }
        public int Numeroverificador { get; set; }
        public string Codigosbs { get; set; }
    }
}