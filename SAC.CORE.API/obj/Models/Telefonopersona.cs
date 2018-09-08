using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Telefonopersona
    {
        public int Secuencial { get; set; }
        public int Secuencialpersona { get; set; }
        public string Codigoempresatelefonica { get; set; }
        public string Codigotipotelefono { get; set; }
        public string Numerotelefono { get; set; }
        public string Descripcion { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }

        public Persona SecuencialpersonaNavigation { get; set; }
    }
}
