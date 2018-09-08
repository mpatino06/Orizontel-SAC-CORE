using System;
using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class PrestamoMaestros
    {
        public int SECUENCIAL { get; set; }

        public string NUMEROPRESTAMO { get; set; }

        public int SECUENCIALEMPRESA { get; set; }

        public string CODIGOTIPOPRESTAMO { get; set; }

        public string CODIGOPRODUCTOCARTERA { get; set; }

        public int SECUENCIALSEGMENTOINTERNO { get; set; }

        public int SECUENCIALCONDICIONTABLAAMORTZ { get; set; }

        public string CODIGOSUBCALIFICACIONCONTABLE { get; set; }

        public int FRECUENCIAPAGO { get; set; }

        public int NUMEROCUOTAS { get; set; }

        public decimal DEUDAINICIAL { get; set; }

        public decimal VALORENTREGADO { get; set; }

        public DateTime FECHAADJUDICACION { get; set; }

        public DateTime FECHAVENCIMIENTO { get; set; }

        public int SECUENCIALMONEDA { get; set; }

        public string CODIGOESTADOPRESTAMO { get; set; }

        public decimal SALDOACTUAL { get; set; }

        public string CALIFICACIONACTUAL { get; set; }

        public string CALIFICACIONPEOR { get; set; }

        public string CODIGOUSUARIOOFICIAL { get; set; }

        public int SECUENCIALOFICINA { get; set; }

        public bool COBRAPORROL { get; set; }

        public bool SEREAJUSTA { get; set; }

        public int DIASREAJUSTE { get; set; }

        public DateTime FECHACORTE { get; set; }

        public decimal TEACONSEGURO { get; set; }

        public decimal TEASINSEGURO { get; set; }

        public bool ESTAVIGENTECLASIFICACION { get; set; }

        public bool BLOQUEADOTRANSACCIONOPERATIVA { get; set; }

        public string NUMEROPAGARE { get; set; }

        public string IDENTIFICACIONSUJETOORIGINAL { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        public Mora _MORA { get; set; }

        public List<PrestamoClientes> _PRESTAMOCLIENTES { get; set; }

        public List<MovimientoDetalle_Prestamo> _MOVIMIENTOS { get; set; }
        public List<PrestamoComponente_Carteras> _SALDOS { get; set; }
        public List<CalificacionPrestamos> _CALIFICACIONPRESTAMOS { get; set; }
    }
}