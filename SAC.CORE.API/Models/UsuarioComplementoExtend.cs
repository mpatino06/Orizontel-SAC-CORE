using System;

namespace SAC.CORE.API.Models
{
    public class UsuarioComplementoExtend
    {
        public string Codigousuario { get; set; }
        public string Nombre { get; set; }
        public int Secuencialoficina { get; set; }
        public bool Estaactivo { get; set; }
        public int NumeroverificadorUsuario { get; set; }
        public int Secuencialpersona { get; set; }
        public DateTime Fechacreacion { get; set; }
        public string Clave { get; set; }
        public string Emailinterno { get; set; }
        public DateTime Fechaultimocambioclave { get; set; }
        public bool Cambioclaveproximoingreso { get; set; }
        public int Periodicidadcambioclave { get; set; }
        public bool Esinterno { get; set; }
        public int NumeroverificadorUsuarioComplemento { get; set; }
        public bool Puedeconsultarotrosusuarios { get; set; }
    }
}