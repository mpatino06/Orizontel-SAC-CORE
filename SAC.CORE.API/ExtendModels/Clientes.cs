using System;
using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class Clientes
    {
        public int SECUENCIAL { get; set; }

        public int SECUENCIALOFICINA { get; set; }

        public int SECUENCIALPERSONA { get; set; }

        public int NUMEROCLIENTE { get; set; }

        public DateTime FECHAINGRESO { get; set; }

        public string CODIGOUSUARIOOFICIAL { get; set; }

        public string CODIGOSECTORECONOMICO { get; set; }

        public string CODIGOTIPOVINCULACION { get; set; }

        public string CODIGOCALIFICACIONINTERNA { get; set; }

        public int SECUENCIALDIVISIONMERCADO { get; set; }

        public string CODIGOESTADOCLIENTE { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        public List<PrestamoClientes> _PRESTAMOSCLIENTES { get; set; }
    }
}