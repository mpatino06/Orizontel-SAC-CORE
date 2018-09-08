namespace SAC.CORE.API.Models
{
    public partial class Tipoeducacion
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Aceptaprofesion { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
        public string Codigosbs { get; set; }
    }
}