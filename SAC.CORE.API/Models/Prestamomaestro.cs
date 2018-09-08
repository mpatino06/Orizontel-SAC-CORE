using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Models
{
    public partial class Prestamomaestro
    {
        public Prestamomaestro()
        {
            Calificacionprestamo = new HashSet<Calificacionprestamo>();
            Prestamocliente = new HashSet<Prestamocliente>();
            PrestamocomponenteCartera = new HashSet<PrestamocomponenteCartera>();
        }

        public int Secuencial { get; set; }
        public string Numeroprestamo { get; set; }
        public int Secuencialempresa { get; set; }
        public string Codigotipoprestamo { get; set; }
        public string Codigoproductocartera { get; set; }
        public int Secuencialsegmentointerno { get; set; }
        public int Secuencialcondiciontablaamortz { get; set; }
        public string Codigosubcalificacioncontable { get; set; }
        public int Frecuenciapago { get; set; }
        public int Numerocuotas { get; set; }
        public decimal Deudainicial { get; set; }
        public decimal Valorentregado { get; set; }
        public DateTime Fechaadjudicacion { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public int Secuencialmoneda { get; set; }
        public string Codigoestadoprestamo { get; set; }
        public decimal Saldoactual { get; set; }
        public string Calificacionactual { get; set; }
        public string Calificacionpeor { get; set; }
        public string Codigousuariooficial { get; set; }
        public int Secuencialoficina { get; set; }
        public bool Cobraporrol { get; set; }
        public bool Sereajusta { get; set; }
        public int Diasreajuste { get; set; }
        public DateTime Fechacorte { get; set; }
        public decimal Teaconseguro { get; set; }
        public decimal Teasinseguro { get; set; }
        public bool Estavigenteclasificacion { get; set; }
        public bool Bloqueadotransaccionoperativa { get; set; }
        public string Numeropagare { get; set; }
        public string Identificacionsujetooriginal { get; set; }
        public int Numeroverificador { get; set; }

        public Estadoprestamo CodigoestadoprestamoNavigation { get; set; }
        public Usuario CodigousuariooficialNavigation { get; set; }
        public ICollection<Calificacionprestamo> Calificacionprestamo { get; set; }
        public ICollection<Prestamocliente> Prestamocliente { get; set; }
        public ICollection<PrestamocomponenteCartera> PrestamocomponenteCartera { get; set; }
    }
}