using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class PrestamoClientes
    {
        public int SECUENCIAL { get; set; }

        public int SECUENCIALPRESTAMO { get; set; }

        public int SECUENCIALCLIENTE { get; set; }

        public bool ESPRINCIPAL { get; set; }

        public bool ESTAACTIVO { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        public List<MoviemientoDetalle_PrestamoCli> _MOVIMIENTOS { get; set; }
    }
}