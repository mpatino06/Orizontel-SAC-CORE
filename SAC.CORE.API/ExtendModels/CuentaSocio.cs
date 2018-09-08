using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class CuentaSocio
    {
        public Personas _Personas { get; set; }
        public List<PrestamoMaestros> _PrestamosMaestros { get; set; }
    }
}