using System;

namespace SAC.CORE.API.ExtendModels
{
    public class SolicitudPrestamo
    {
        //solicitudMaestro
        public int Secuencial { get; set; }

        public int NumeroSolicitud { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CodigoEstadoSolicitud { get; set; }
        public string EstadoSolicitud { get; set; }
        public string CodigoUsuarioIngreso { get; set; }
        public string SecuencialOficina { get; set; }
        public bool EsRenovacion { get; set; }
        public int NumeroVerificador { get; set; }
        public int NumeroPrestamoMigra { get; set; }
        public string NumerosocioMigra { get; set; }

        //SolicitudMaestroPrestamo
        public string CodigoTipoPrestamo { get; set; }

        public string TipoPrestamo { get; set; }
        public string CodigoProductoCartera { get; set; }
        public string ProductoCartera { get; set; }
        public int SecuencialSegmentoInterno { get; set; }
        public string SegmentoInterno { get; set; }
        public int SecuencialCondiccionTablaAmortz { get; set; }
        public string CondiccionTablaAmortz { get; set; }
        public string CodigoSubcalificacionContable { get; set; }
        public string SubcalificacionContable { get; set; }
        public int FrecuenciaPago { get; set; }
        public int NumeroCuotas { get; set; }
        public bool CobraporRol { get; set; }
        public string CodigoOrigenRecurso { get; set; }
    }
}