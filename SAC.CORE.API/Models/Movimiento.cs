using System;

namespace SAC.CORE.API.Models
{
    public partial class Movimiento
    {
        public int Secuencial { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fechamaquina { get; set; }
        public string Codigousuario { get; set; }
        public int Secuencialoficinausuario { get; set; }
        public bool Estaimpreso { get; set; }
        public int Numeroverificador { get; set; }
    }
}