using SAC.CORE.API.Models;
using System;

namespace SAC.CORE.API.ExtendModels
{
    public class DepositoPlazoFijo
    {
        public int SecuencialCuenta { get; set; }
        public int Secuencial { get; set; }
        public string Codigo { get; set; }
        public string Codigotipodeposito { get; set; }
        public string Codigoproductoplazo { get; set; }
        public decimal Monto { get; set; }
        public decimal Tasa { get; set; }
        public decimal Variaciontasa { get; set; }
        public int Plazoendias { get; set; }
        public bool Pagoperiodicointeres { get; set; }
        public DateTime Fechacreacion { get; set; }
        public string Codigoestadodeposito { get; set; }
        public int Secuencialmoneda { get; set; }
        public int Secuencialoficina { get; set; }
        public string Codigousuario { get; set; }
        public DateTime Fechamaquinacreacion { get; set; }
        public DateTime? Fechacorte { get; set; }
        public int NumeroverificadorDepositoMaestro { get; set; }
        public int? Secuencialempresa { get; set; }
        public string Identificacionsujetooriginal { get; set; }
        public int SecuencialCliente { get; set; }
        public bool EsPrincipal { get; set; }
        public bool EsConjunto { get; set; }
        public bool EstaActivo { get; set; }
        public int NumeroverificadorDepositoCliente { get; set; }
        public int Secuencialcomponenteplazo { get; set; }
        public string Codigotipocancelacion { get; set; }
        public decimal SaldoDepositoCompPlazo { get; set; }
        public int NumeroverificadorCompPlazo { get; set; }
        public int NumeroverificadorDepositoCompPlazoRangoTemp { get; set; }
        public Depositobeneficiario Beneficiario { get; set; }
        public int SecuencialMovimientoDetalle { get; set; }
    }
}