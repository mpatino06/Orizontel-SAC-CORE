using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class Personas
    {
        public int SECUENCIAL { get; set; }

        public string IDENTIFICACION { get; set; }

        public string NOMBREUNIDO { get; set; }

        public string DIRECCIONDOMICILIO { get; set; }

        public string REFERENCIADOMICILIARIA { get; set; }

        public string EMAIL { get; set; }

        public int SECUENCIALTIPOIDENTIFICACION { get; set; }

        public int SECUENCIALDIVPOLRESIDENCIA { get; set; }

        public string CODIGOPAISORIGEN { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        public int SECUENCIALDIVACTIVIDADECON { get; set; }

        public string CODIGOSOCIOMIGRA { get; set; }

        public string IDENTIFICACIONMIGRA { get; set; }

        public Clientes _CLIENTES { get; set; }

        public List<TelefonoPersonas> _TELEFONOPERSONAS { get; set; }
    }
}