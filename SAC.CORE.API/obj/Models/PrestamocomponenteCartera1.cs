using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class PrestamocomponenteCartera1
    {
        public DateTime Fechahistorico { get; set; }
        public DateTime Fechamodifica { get; set; }
        public int Secuencial { get; set; }
        public int Secuencialprestamo { get; set; }
        public int Secuencialcomponentecartera { get; set; }
        public decimal Valorproyectado { get; set; }
        public decimal Valorcalculado { get; set; }
        public decimal Valorcobrado { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public int Numerocuota { get; set; }
        public string Codigoestadoprestamocomponente { get; set; }
        public decimal Factorcalculo { get; set; }
        public int Diascalculados { get; set; }
    }
}
