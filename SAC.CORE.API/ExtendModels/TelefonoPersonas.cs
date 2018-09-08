namespace SAC.CORE.API.ExtendModels
{
    public class TelefonoPersonas
    {
        public int SECUENCIAL { get; set; }

        public int SECUENCIALPERSONA { get; set; }

        public string CODIGOEMPRESATELEFONICA { get; set; }

        public string CODIGOTIPOTELEFONO { get; set; }

        public string NUMEROTELEFONO { get; set; }

        public string DESCRIPCION { get; set; }

        public bool ESTAACTIVO { get; set; }

        public int NUMEROVERIFICADOR { get; set; }
    }
}