using SAC.CORE.API.ModelAdmin;
using System;
using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class AdminUsuario
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Activo { get; set; }
        public string Imagen { get; set; }
        public string TextoImagen { get; set; }
        public string Message { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public bool CodigoPermitido { get; set; }
        public string RutaImagen { get; set; }
        public DateTime UltimoIgreso { get; set; }
        public List<Usuariopregunta> preguntas { get; set; }
    }
}