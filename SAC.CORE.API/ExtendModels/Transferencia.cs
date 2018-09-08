using System;

namespace SAC.CORE.API.ExtendModels
{
    public class Transferencia
    {
        public int SecuencialMovimiento { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaMaquina { get; set; }
        public string CodigousuarioOficina { get; set; }
        public int Secuencialoficinausuario { get; set; }
        public bool Estaimpreso { get; set; }
        public int Numeroverificador { get; set; }
        public int SecuencialMovimientoDetalle { get; set; }
        public int Secuencialtransaccion { get; set; }
        public int Secuencialmoneda { get; set; }
        public decimal Valor { get; set; }
        public int Secuencialcuenta { get; set; }
        public decimal Saldocuenta { get; set; }
        public string Codigoestadocuenta { get; set; }
    }
}