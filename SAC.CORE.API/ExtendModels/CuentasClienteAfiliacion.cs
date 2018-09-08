namespace SAC.CORE.API.ExtendModels
{
    public class CuentasClienteAfiliacion
    {
        public int IdAfiliacion { get; set; }
        public int SecuencialCuenta { get; set; }
        public string TipoDocumento { get; set; }
        public string Identificacion { get; set; }
        public string TipoCuenta { get; set; }
        public string Libreta { get; set; }
        public string NombreUnido { get; set; }
        public string NombreAfiliado { get; set; }
        public string Email { get; set; }
        public int SecuencialCliente { get; set; }
    }
}