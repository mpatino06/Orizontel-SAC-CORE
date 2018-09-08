using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC.CORE.API.Models
{
    public partial class Depositodocumentofisico
    {
        public int Secuencial { get; set; }
        public int Secuencialdeposito { get; set; }
        public string Codigousuario { get; set; }
        public DateTime Fechasistema { get; set; }
        public DateTime Fechamaquina { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
        public string Documentofisico { get; set; }
    }
}
