using System;

namespace SAC.CORE.API.ExtendModels
{
    public class AfiliacionServicios
    {
        public int IdAfiliciacionCliente { get; set; }
        public string IdentificacionUsuario { get; set; }
        public string IdentificacionCliente { get; set; }
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string NombreBeneficiario { get; set; }
        public int SecuencialCuenta { get; set; }
        public string NombreAfiliacion { get; set; }
        public string NumeroCuenta { get; set; }
        public string CodigoBanco { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMaximo { get; set; }
        public bool EstaActivo { get; set; }
    }
}