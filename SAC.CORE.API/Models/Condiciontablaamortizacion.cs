namespace SAC.CORE.API.Models
{
    public class Condiciontablaamortizacion
    {
        public int Secuencial { get; set; }
        public bool Escuotafija { get; set; }
        public string Codigogeneracionvenccuota { get; set; }
        public bool Esconalicuota { get; set; }
        public bool Esinteresessobresaldo { get; set; }
        public bool Aumentaprimeracuota { get; set; }
        public int Secuencialempresa { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
        public string Nombre { get; set; }
    }
}