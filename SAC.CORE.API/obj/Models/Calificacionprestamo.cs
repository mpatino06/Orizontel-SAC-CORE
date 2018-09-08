using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Calificacionprestamo
    {
        public int Secuencial { get; set; }
        public int Secuencialprestamo { get; set; }
        public int Diasmorosidad { get; set; }
        public decimal Saldoprestamo { get; set; }
        public int Secuencialcondicioncalifaut { get; set; }
        public int Secuencialcondicioncalifmanual { get; set; }
        public decimal Provisionautomatica { get; set; }
        public decimal Provisionmanual { get; set; }
        public decimal Provisionconstituida { get; set; }
        public string Codigousuario { get; set; }
        public DateTime Fechacalificacion { get; set; }
        public DateTime Fechamaquina { get; set; }
        public int Numeroverificador { get; set; }
        public bool? Eshomologada { get; set; }
        public decimal? Provisionoriginal { get; set; }
        public int? Secuencialcondcalifautoriginal { get; set; }

        public Usuario CodigousuarioNavigation { get; set; }
        public Prestamomaestro SecuencialprestamoNavigation { get; set; }
    }
}
