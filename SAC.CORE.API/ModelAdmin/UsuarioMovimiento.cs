using System;

namespace SAC.CORE.API.ModelAdmin
{
    public partial class UsuarioMovimiento
    {
        public int IdUsuarioMovimiento { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
    }
}