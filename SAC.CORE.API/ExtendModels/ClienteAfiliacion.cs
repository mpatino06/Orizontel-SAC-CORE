namespace SAC.CORE.API.ExtendModels
{
    public class ClienteAfiliacion
    {
        public int IdAfiliciacionCliente { get; set; }
        public int IdUsuario { get; set; }
        public string IdentificacionCliente { get; set; }
        public int SecuencialCuenta { get; set; }
        public string NombreAfiliacion { get; set; }
        public string NumeroCuenta { get; set; }
        public string CodigoBanco { get; set; }
        public bool EstaActivo { get; set; }
    }
}