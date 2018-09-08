using System;

namespace SAC.CORE.API.Models
{
    public partial class Depositomaestro
    {
        public int Secuencial { get; set; }
        public string Codigo { get; set; }
        public string Codigotipodeposito { get; set; }
        public string Codigoproductoplazo { get; set; }
        public decimal Monto { get; set; }
        public decimal Tasa { get; set; }
        public decimal Variaciontasa { get; set; }
        public int Plazoendias { get; set; }
        public bool Pagoperiodicointeres { get; set; }
        public DateTime Fechacreacion { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public string Codigoestadodeposito { get; set; }
        public int Secuencialmoneda { get; set; }
        public int Secuencialoficina { get; set; }
        public string Codigousuario { get; set; }
        public DateTime Fechamaquinacreacion { get; set; }
        public DateTime? Fechacorte { get; set; }
        public int Numeroverificador { get; set; }
        public int? Secuencialempresa { get; set; }
        public string Identificacionsujetooriginal { get; set; }
    }
}