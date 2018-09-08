using System;

namespace SAC.CORE.API.Models
{
    public class Personanatural
    {
        public Personanatural()
        {
        }

        public int Secuencialpersona { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Esmasculino { get; set; }
        public string Codigoestadocivil { get; set; }
        public string Codigotipoeducacion { get; set; }
        public string Codigotipovivienda { get; set; }
        public string Codigoprofesion { get; set; }
        public decimal Egresosmensuales { get; set; }
        public decimal Patrimonio { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Lugarnacimiento { get; set; }
        public decimal Activostotales { get; set; }
        public decimal Pasivostotales { get; set; }
        public int Cargasfamiliares { get; set; }
    }
}