using System;

namespace SAC.CORE.API.ExtendModels
{
    public class PrestamoComponente_Carteras
    {
        public int SECUENCIAL { get; set; }

        public int SECUENCIALPRESTAMO { get; set; }

        public int SECUENCIALCOMPONENTECARTERA { get; set; }

        public decimal VALORPROYECTADO { get; set; }

        public decimal VALORCALCULADO { get; set; }

        public decimal VALORCOBRADO { get; set; }

        public DateTime FECHAINICIO { get; set; }

        public DateTime FECHAVENCIMIENTO { get; set; }

        public int NUMEROCUOTA { get; set; }

        public string CODIGOESTADOPRESTAMOCOMPONENTE { get; set; }

        public decimal FACTORCALCULO { get; set; }

        public int DIASCALCULADOS { get; set; }
    }
}