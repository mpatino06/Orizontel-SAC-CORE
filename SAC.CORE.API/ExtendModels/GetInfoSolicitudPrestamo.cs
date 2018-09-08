using SAC.CORE.API.Models;
using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class GetInfoSolicitudPrestamo
    {
        public List<TipoPrestamo> prestamos { get; set; }
        public List<Condiciontablaamortizacion> amortizacion { get; set; }
    }
}