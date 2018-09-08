using System;

namespace SAC.CORE.API.Models
{
    public partial class Cuentamaestro
    {
        public int Secuencial { get; set; }

        public string Codigo { get; set; }
        public string Codigotipocuenta { get; set; }
        public string Codigoproductovista { get; set; }
        public string Codigoestado { get; set; }
        public int Secuencialmoneda { get; set; }
        public int Secuencialoficina { get; set; }
        public string Codigousuariooficial { get; set; }
        public DateTime Fechasistemacreacion { get; set; }
        public DateTime Fechamaquinacreacion { get; set; }
        public int Numerolibreta { get; set; }
        public int Numeroimprimelibreta { get; set; }
        public bool Esanverso { get; set; }
        public bool Tieneseguroactivo { get; set; }
        public DateTime Fechacorte { get; set; }
        public bool Bloqueadatransaccionoperativa { get; set; }
        public int Numeroverificador { get; set; }
    }
}