namespace SAC.CORE.API.Models
{
    public partial class Depositobeneficiario
    {
        public int Secuencial { get; set; }
        public int Secuencialdeposito { get; set; }
        public string Beneficiario { get; set; }
        public string Parentesco { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Numeroverificador { get; set; }
        public bool Esconjunto { get; set; }
        public string Identificacionbeneficiario { get; set; }
    }
}