using System;

namespace SAC.CORE.API.ExtendModels
{
    public class CalificacionPrestamos
    {
        public int SECUENCIAL { get; set; }
        public int SECUENCIALPRESTAMO { get; set; }
        public int DIASMOROSIDAD { get; set; }
        public decimal SALDOPRESTAMO { get; set; }
        public int SECUENCIALCONDICIONCALIFAUT { get; set; }
        public int SECUENCIALCONDICIONCALIFMANUAL { get; set; }
        public decimal PROVISIONAUTOMATICA { get; set; }
        public decimal PROVISIONMANUAL { get; set; }
        public decimal PROVISIONCONSTITUIDA { get; set; }
        public string CODIGOUSUARIO { get; set; }
        public DateTime FECHACALIFICACION { get; set; }
        public string FECHACALIFICACION_MES_ANO { get; set; }
        public DateTime FECHAMAQUINA { get; set; }
        public int NUMEROVERIFICADOR { get; set; }
        public bool? ESHOMOLOGADA { get; set; }
        public decimal? PROVISIONORIGINAL { get; set; }
        public int? SECUENCIALCONDCALIFAUTORIGINAL { get; set; }
    }
}