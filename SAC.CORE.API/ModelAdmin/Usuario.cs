using System;

namespace SAC.CORE.API.ModelAdmin
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Activo { get; set; }
        public string Imagen { get; set; }
        public string TextoImagen { get; set; }
    }
}