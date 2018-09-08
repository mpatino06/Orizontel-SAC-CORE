using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            //Calificacionprestamo = new HashSet<Calificacionprestamo>();
            //Cliente = new HashSet<Cliente>();
            //Prestamomaestro = new HashSet<Prestamomaestro>();
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Secuencialoficina { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }

        public UsuarioComplemento UsuarioComplemento { get; set; }
        //public UsuarioComplemento1 UsuarioComplemento1 { get; set; }
        //public ICollection<Calificacionprestamo> Calificacionprestamo { get; set; }
        //public ICollection<Cliente> Cliente { get; set; }
        //public ICollection<Prestamomaestro> Prestamomaestro { get; set; }
    }
}
