using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class MovimientodetallePrestamocli
    {
        public int Secuencial { get; set; }
        public int Secuencialmovdetalleprestamo { get; set; }
        public int Secuencialprestamocliente { get; set; }
        public decimal Valor { get; set; }

        public Prestamocliente SecuencialprestamoclienteNavigation { get; set; }
    }
}
