using System;

namespace SAC.CORE.API.Models
{
    public partial class Solicitudmaestro
    {
        public int Secuencial { get; set; }
        public int Numerosolicitud { get; set; }
        public decimal Montosolicitado { get; set; }
        public decimal Montoaprobado { get; set; }
        public DateTime Fechaingreso { get; set; }
        public string Codigoestadosolicitud { get; set; }
        public string Codigousuarioingreso { get; set; }
        public int Secuencialoficina { get; set; }
        public bool? Esrenovacion { get; set; }
        public int Numeroverificador { get; set; }
        public string Numeroprestamomigra { get; set; }
        public string Numerosociomigra { get; set; }
    }
}