using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class ClienteMovimientoSaldos
    {
        public Personas _PERSONAS { get; set; }

        public List<PrestamoMaestros> _SALDOS_PAGOS { get; set; }
    }
}