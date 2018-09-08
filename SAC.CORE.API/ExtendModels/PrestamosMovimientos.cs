using System;

namespace SAC.CORE.API.ExtendModels
{
    public class PrestamosMovimientos
    {
        public int Secuencial { get; set; }
        public int SecuencialMovimientoDetalle { get; set; }
        public int SecuencialPrestamo { get; set; }
        public int SecuencialComponenteCartera { get; set; }
        public string CodigoTipoMovimiento { get; set; }
        public int Numerocuota { get; set; }
        public string NombreComponente { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public string CodigoEstadoPrestamoComponente { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoPrestamo { get; set; }
        public decimal ValorMovimientoDetalle { get; set; }
        public string NumeroPrestamo { get; set; }
    }
}