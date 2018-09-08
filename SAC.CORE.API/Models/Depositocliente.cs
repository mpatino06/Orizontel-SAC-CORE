namespace SAC.CORE.API.Models
{
    public partial class Depositocliente
    {
        public int Secuencial { get; set; }
        public int Secuencialdeposito { get; set; }
        public int Secuencialcliente { get; set; }
        public bool Esprincipal { get; set; }
        public bool Esconjunto { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
    }
}