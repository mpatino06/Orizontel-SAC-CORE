namespace SAC.CORE.API.Models
{
    public partial class Rangotemporizacion
    {
        public int Secuencial { get; set; }
        public int Secuencialempresa { get; set; }
        public int Diasinicio { get; set; }
        public int Diasfinal { get; set; }
        public int Secuencialcuentacontable { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
    }
}