using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Estadoprestamo
    {
        public Estadoprestamo()
        {
            Prestamomaestro = new HashSet<Prestamomaestro>();
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Color { get; set; }
        public string Imagen { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }

        public ICollection<Prestamomaestro> Prestamomaestro { get; set; }
    }
}
