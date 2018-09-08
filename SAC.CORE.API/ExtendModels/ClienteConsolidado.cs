using SAC.CORE.API.Models;
using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class ClienteConsolidado
    {
        public string Identificacion { get; set; }
        public string NombreUnido { get; set; }
        public List<ClienteCuentas> Cuentas { get; set; }
        public List<PrestamoMaestros> Prestamos { get; set; }
        public List<Depositomaestro> DspositoPF { get; set; }
    }
}