using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class MovimientoDetalle_Prestamo
    {
        public int SECUENCIALMOVIMIENTODETALLE { get; set; }

        public int SECUENCIALPRESTAMO { get; set; }

        public decimal SALDOPRESTAMO { get; set; }

        public string CODIGOESTADOPRESTAMO { get; set; }
        public List<MoviemientoDetalle_PrestamoCli> _MOVIMIENTOSDETALLES { get; set; }
    }
}