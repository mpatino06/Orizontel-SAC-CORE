namespace SAC.CORE.API.Models
{
    public class Estadocivil
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool RequiereConyugue { get; set; }
        public bool EstaActivo { get; set; }
        public int NumeroVerificador { get; set; }
        public string Codigosbs { get; set; }
    }
}