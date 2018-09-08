using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Prestamocliente
    {
        public Prestamocliente()
        {
            MovimientodetallePrestamocli = new HashSet<MovimientodetallePrestamocli>();
        }

        public int Secuencial { get; set; }
        public int Secuencialprestamo { get; set; }
        public int Secuencialcliente { get; set; }
        public bool Esprincipal { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }

        public Cliente SecuencialclienteNavigation { get; set; }
        public Prestamomaestro SecuencialprestamoNavigation { get; set; }
        public ICollection<MovimientodetallePrestamocli> MovimientodetallePrestamocli { get; set; }
    }
}
