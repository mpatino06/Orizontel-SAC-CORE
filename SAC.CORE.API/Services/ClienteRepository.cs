using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using SAC.CORE.API.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace SAC.CORE.API.Services
{
    public class ClienteRepository : ICliente
    {
        private FBS_SacAmbatoContext context;
        private AdminTransaccionalContext adminTransaccional;

        private int SecuencialMovimientoDetalle { get; set; }

        public ClienteRepository()
        {
            context = new FBS_SacAmbatoContext();
            adminTransaccional = new AdminTransaccionalContext();
        }

        public CuentaSocio GetCuentaSocio(string code)
        {
            CuentaSocio cuentasocio = new CuentaSocio();
            int numeroCliente = 0;
            bool isNum = int.TryParse(code, out int Num);
            numeroCliente = isNum ? Num : 0;
            try
            {
                var x = from p in context.Persona
                        where p.Identificacion == code
                        select p;

                cuentasocio = (from per in context.Persona
                               join cli in context.Cliente on per.Secuencial equals cli.Secuencialpersona
                               where per.Identificacion == code || cli.Numerocliente == numeroCliente
                               select new CuentaSocio
                               {
                                   _Personas = new Personas
                                   {
                                       SECUENCIAL = per.Secuencial,
                                       IDENTIFICACION = per.Identificacion,
                                       NOMBREUNIDO = per.Nombreunido,
                                       DIRECCIONDOMICILIO = per.Direcciondomicilio,
                                       REFERENCIADOMICILIARIA = per.Referenciadomiciliaria,
                                       EMAIL = per.Email,
                                       SECUENCIALTIPOIDENTIFICACION = per.Secuencialtipoidentificacion,
                                       SECUENCIALDIVPOLRESIDENCIA = per.Secuencialdivpolresidencia,
                                       CODIGOPAISORIGEN = per.Codigopaisorigen,
                                       NUMEROVERIFICADOR = per.Numeroverificador,
                                       SECUENCIALDIVACTIVIDADECON = per.Secuencialdivactividadecon,
                                       CODIGOSOCIOMIGRA = per.Codigosociomigra.Trim(),
                                       IDENTIFICACIONMIGRA = per.Identificacionmigra,
                                       _CLIENTES = new Clientes
                                       {
                                           SECUENCIAL = cli.Secuencial,
                                           SECUENCIALOFICINA = cli.Secuencialoficina,
                                           SECUENCIALPERSONA = cli.Secuencialpersona,
                                           NUMEROCLIENTE = cli.Numerocliente,
                                           FECHAINGRESO = cli.Fechaingreso,
                                           CODIGOUSUARIOOFICIAL = cli.Codigousuariooficial,
                                           CODIGOSECTORECONOMICO = cli.Codigosectoreconomico,
                                           CODIGOTIPOVINCULACION = cli.Codigotipovinculacion,
                                           CODIGOCALIFICACIONINTERNA = cli.Codigocalificacioninterna,
                                           SECUENCIALDIVISIONMERCADO = cli.Secuencialdivisionmercado,
                                           CODIGOESTADOCLIENTE = cli.Codigoestadocliente,
                                           NUMEROVERIFICADOR = cli.Numeroverificador
                                       },
                                       _TELEFONOPERSONAS = (from det in context.Telefonopersona
                                                            where det.Secuencialpersona == per.Secuencial
                                                            select new TelefonoPersonas
                                                            {
                                                                SECUENCIAL = det.Secuencial,
                                                                SECUENCIALPERSONA = det.Secuencialpersona,
                                                                CODIGOEMPRESATELEFONICA = det.Codigoempresatelefonica,
                                                                CODIGOTIPOTELEFONO = det.Codigotipotelefono,
                                                                NUMEROTELEFONO = det.Numerotelefono,
                                                                DESCRIPCION = det.Descripcion,
                                                                ESTAACTIVO = det.Estaactivo,
                                                                NUMEROVERIFICADOR = det.Numeroverificador
                                                            }).ToList()
                                   },
                                   _PrestamosMaestros = (from prema in context.Prestamomaestro
                                                         where prema.Codigousuariooficial == cli.Codigousuariooficial
                                                         select new PrestamoMaestros
                                                         {
                                                             SECUENCIAL = prema.Secuencial,
                                                             NUMEROPRESTAMO = prema.Numeroprestamo,
                                                             SECUENCIALEMPRESA = prema.Secuencialempresa,
                                                             CODIGOTIPOPRESTAMO = prema.Codigotipoprestamo,
                                                             CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                                             SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                                             SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                                             CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                                             FRECUENCIAPAGO = prema.Frecuenciapago,
                                                             NUMEROCUOTAS = prema.Numerocuotas,
                                                             DEUDAINICIAL = prema.Deudainicial,
                                                             VALORENTREGADO = prema.Valorentregado,
                                                             FECHAADJUDICACION = prema.Fechaadjudicacion,
                                                             FECHAVENCIMIENTO = prema.Fechavencimiento,
                                                             SECUENCIALMONEDA = prema.Secuencialmoneda,
                                                             CODIGOESTADOPRESTAMO = prema.Codigoestadoprestamo,
                                                             SALDOACTUAL = prema.Saldoactual,
                                                             CALIFICACIONACTUAL = prema.Calificacionactual,
                                                             CALIFICACIONPEOR = prema.Calificacionpeor,
                                                             CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                                             SECUENCIALOFICINA = prema.Secuencialoficina,
                                                             COBRAPORROL = prema.Cobraporrol,
                                                             SEREAJUSTA = prema.Sereajusta,
                                                             DIASREAJUSTE = prema.Diasreajuste,
                                                             FECHACORTE = prema.Fechacorte,
                                                             TEACONSEGURO = prema.Teaconseguro,
                                                             TEASINSEGURO = prema.Teasinseguro,
                                                             ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                                             BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                                             NUMEROPAGARE = prema.Numeropagare,
                                                             IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                                             NUMEROVERIFICADOR = prema.Numeroverificador,
                                                             _PRESTAMOCLIENTES = (from preclie in context.Prestamocliente
                                                                                  where preclie.Secuencialprestamo == prema.Secuencial
                                                                                  select new PrestamoClientes
                                                                                  {
                                                                                      SECUENCIAL = preclie.Secuencial,
                                                                                      SECUENCIALPRESTAMO = preclie.Secuencialprestamo,
                                                                                      SECUENCIALCLIENTE = preclie.Secuencialcliente,
                                                                                      ESPRINCIPAL = preclie.Esprincipal,
                                                                                      ESTAACTIVO = preclie.Estaactivo,
                                                                                      NUMEROVERIFICADOR = preclie.Numeroverificador,
                                                                                  }).ToList()
                                                         }).ToList()
                               }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                cuentasocio = null;
            }
            return cuentasocio;
        }

        public ClienteMovimientoSaldos GetMovimientoSaldos(string code)
        {
            int numeroCliente = 0;
            bool isNum = int.TryParse(code, out int Num);
            numeroCliente = isNum ? Num : 0;

            ClienteMovimientoSaldos clienteMovimientoSaldos = new ClienteMovimientoSaldos();
            try
            {
                clienteMovimientoSaldos = (from per in context.Persona
                                           join cli in context.Cliente on per.Secuencial equals cli.Secuencialpersona
                                           join usua in context.Usuario on cli.Codigousuariooficial equals usua.Codigo
                                           where per.Identificacion == code || cli.Numerocliente == numeroCliente
                                           select new ClienteMovimientoSaldos
                                           {
                                               _PERSONAS = new Personas
                                               {
                                                   SECUENCIAL = per.Secuencial,
                                                   IDENTIFICACION = per.Identificacion,
                                                   NOMBREUNIDO = per.Nombreunido,
                                                   DIRECCIONDOMICILIO = per.Direcciondomicilio,
                                                   REFERENCIADOMICILIARIA = per.Referenciadomiciliaria,
                                                   EMAIL = per.Email,
                                                   SECUENCIALTIPOIDENTIFICACION = per.Secuencialtipoidentificacion,
                                                   SECUENCIALDIVPOLRESIDENCIA = per.Secuencialdivpolresidencia,
                                                   CODIGOPAISORIGEN = per.Codigopaisorigen,
                                                   NUMEROVERIFICADOR = per.Numeroverificador,
                                                   SECUENCIALDIVACTIVIDADECON = per.Secuencialdivactividadecon,
                                                   CODIGOSOCIOMIGRA = per.Codigosociomigra.Trim(),
                                                   IDENTIFICACIONMIGRA = per.Identificacionmigra,
                                                   _CLIENTES = new Clientes
                                                   {
                                                       SECUENCIAL = cli.Secuencial,
                                                       SECUENCIALOFICINA = cli.Secuencialoficina,
                                                       SECUENCIALPERSONA = cli.Secuencialpersona,
                                                       NUMEROCLIENTE = cli.Numerocliente,
                                                       FECHAINGRESO = cli.Fechaingreso,
                                                       CODIGOUSUARIOOFICIAL = cli.Codigousuariooficial,
                                                       CODIGOSECTORECONOMICO = cli.Codigosectoreconomico,
                                                       CODIGOTIPOVINCULACION = cli.Codigotipovinculacion,
                                                       CODIGOCALIFICACIONINTERNA = cli.Codigocalificacioninterna,
                                                       SECUENCIALDIVISIONMERCADO = cli.Secuencialdivisionmercado,
                                                       CODIGOESTADOCLIENTE = cli.Codigoestadocliente,
                                                       NUMEROVERIFICADOR = cli.Numeroverificador,
                                                       _PRESTAMOSCLIENTES = (from preclie in context.Prestamocliente
                                                                             where preclie.Secuencialcliente == cli.Secuencial
                                                                             select new PrestamoClientes
                                                                             {
                                                                                 SECUENCIAL = preclie.Secuencial,
                                                                                 SECUENCIALPRESTAMO = preclie.Secuencialprestamo,
                                                                                 SECUENCIALCLIENTE = preclie.Secuencialcliente,
                                                                                 ESPRINCIPAL = preclie.Esprincipal,
                                                                                 ESTAACTIVO = preclie.Estaactivo,
                                                                                 NUMEROVERIFICADOR = preclie.Numeroverificador,
                                                                                 _MOVIMIENTOS = (from movdet in context.MovimientodetallePrestamocli
                                                                                                 where movdet.Secuencialprestamocliente == preclie.Secuencial
                                                                                                 select new MoviemientoDetalle_PrestamoCli
                                                                                                 {
                                                                                                     SECUENCIAL = movdet.Secuencial,
                                                                                                     SECUENCIALMOVDETALLEPRESTAMO = movdet.Secuencialmovdetalleprestamo,
                                                                                                     SECUENCIALPRESTAMOCLIENTE = movdet.Secuencialprestamocliente,
                                                                                                     VALOR = movdet.Valor
                                                                                                 }).ToList()
                                                                             }).ToList()
                                                   }
                                               },
                                               _SALDOS_PAGOS = (from prema in context.Prestamomaestro
                                                                where prema.Codigousuariooficial == usua.Codigo
                                                                select new PrestamoMaestros
                                                                {
                                                                    SECUENCIAL = prema.Secuencial,
                                                                    NUMEROPRESTAMO = prema.Numeroprestamo,
                                                                    SECUENCIALEMPRESA = prema.Secuencialempresa,
                                                                    CODIGOTIPOPRESTAMO = prema.Codigotipoprestamo,
                                                                    CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                                                    SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                                                    SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                                                    CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                                                    FRECUENCIAPAGO = prema.Frecuenciapago,
                                                                    NUMEROCUOTAS = prema.Numerocuotas,
                                                                    DEUDAINICIAL = prema.Deudainicial,
                                                                    VALORENTREGADO = prema.Valorentregado,
                                                                    FECHAADJUDICACION = prema.Fechaadjudicacion,
                                                                    FECHAVENCIMIENTO = prema.Fechavencimiento,
                                                                    SECUENCIALMONEDA = prema.Secuencialmoneda,
                                                                    CODIGOESTADOPRESTAMO = prema.Codigoestadoprestamo,
                                                                    SALDOACTUAL = prema.Saldoactual,
                                                                    CALIFICACIONACTUAL = prema.Calificacionactual,
                                                                    CALIFICACIONPEOR = prema.Calificacionpeor,
                                                                    CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                                                    SECUENCIALOFICINA = prema.Secuencialoficina,
                                                                    COBRAPORROL = prema.Cobraporrol,
                                                                    SEREAJUSTA = prema.Sereajusta,
                                                                    DIASREAJUSTE = prema.Diasreajuste,
                                                                    FECHACORTE = prema.Fechacorte,
                                                                    TEACONSEGURO = prema.Teaconseguro,
                                                                    TEASINSEGURO = prema.Teasinseguro,
                                                                    ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                                                    BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                                                    NUMEROPAGARE = prema.Numeropagare,
                                                                    IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                                                    NUMEROVERIFICADOR = prema.Numeroverificador,
                                                                    _SALDOS = (from precomcar in context.PrestamocomponenteCartera
                                                                               where precomcar.Secuencialprestamo == prema.Secuencial
                                                                               select new PrestamoComponente_Carteras
                                                                               {
                                                                                   SECUENCIAL = precomcar.Secuencial,
                                                                                   SECUENCIALPRESTAMO = precomcar.Secuencialprestamo,
                                                                                   SECUENCIALCOMPONENTECARTERA = precomcar.Secuencialcomponentecartera,
                                                                                   VALORPROYECTADO = precomcar.Valorproyectado,
                                                                                   VALORCALCULADO = precomcar.Valorcalculado,
                                                                                   VALORCOBRADO = precomcar.Valorcobrado,
                                                                                   FECHAINICIO = precomcar.Fechainicio,
                                                                                   FECHAVENCIMIENTO = precomcar.Fechavencimiento,
                                                                                   NUMEROCUOTA = precomcar.Numerocuota,
                                                                                   CODIGOESTADOPRESTAMOCOMPONENTE = precomcar.Codigoestadoprestamocomponente,
                                                                                   FACTORCALCULO = precomcar.Factorcalculo,
                                                                                   DIASCALCULADOS = precomcar.Diascalculados
                                                                               }).ToList()
                                                                }).ToList()
                                           }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                clienteMovimientoSaldos = null;
            }
            return clienteMovimientoSaldos;
        }

        public List<PrestamoMaestros> GetClientesMora(string usuario, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<PrestamoMaestros> clientesMora = new List<PrestamoMaestros>();
            try
            {
                clientesMora = (from prema in context.Prestamomaestro
                                where prema.Codigousuariooficial == usuario &&
                                (prema.Fechaadjudicacion.Date >= fechaInicial && prema.Fechaadjudicacion.Date <= fechaFinal)
                                select new PrestamoMaestros
                                {
                                    SECUENCIAL = prema.Secuencial,
                                    NUMEROPRESTAMO = prema.Numeroprestamo,
                                    SECUENCIALEMPRESA = prema.Secuencialempresa,
                                    CODIGOTIPOPRESTAMO = prema.Codigotipoprestamo,
                                    CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                    SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                    SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                    CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                    FRECUENCIAPAGO = prema.Frecuenciapago,
                                    NUMEROCUOTAS = prema.Numerocuotas,
                                    DEUDAINICIAL = prema.Deudainicial,
                                    VALORENTREGADO = prema.Valorentregado,
                                    FECHAADJUDICACION = prema.Fechaadjudicacion,
                                    FECHAVENCIMIENTO = prema.Fechavencimiento,
                                    SECUENCIALMONEDA = prema.Secuencialmoneda,
                                    CODIGOESTADOPRESTAMO = prema.Codigoestadoprestamo,
                                    SALDOACTUAL = prema.Saldoactual,
                                    CALIFICACIONACTUAL = prema.Calificacionactual,
                                    CALIFICACIONPEOR = prema.Calificacionpeor,
                                    CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                    SECUENCIALOFICINA = prema.Secuencialoficina,
                                    COBRAPORROL = prema.Cobraporrol,
                                    SEREAJUSTA = prema.Sereajusta,
                                    DIASREAJUSTE = prema.Diasreajuste,
                                    FECHACORTE = prema.Fechacorte,
                                    TEACONSEGURO = prema.Teaconseguro,
                                    TEASINSEGURO = prema.Teasinseguro,
                                    ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                    BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                    NUMEROPAGARE = prema.Numeropagare,
                                    IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                    NUMEROVERIFICADOR = prema.Numeroverificador,
                                    _MORA = GetMora(prema.Secuencial),
                                    //_SALDOS = (from precomcar in context.PrestamocomponenteCartera
                                    //           where precomcar.Secuencialprestamo == prema.Secuencial
                                    //           && precomcar.Codigoestadoprestamocomponente == "V"
                                    //           && precomcar.Secuencialcomponentecartera == 44
                                    //           select new PrestamoComponente_Carteras
                                    //           {
                                    //               SECUENCIAL = precomcar.Secuencial,
                                    //               SECUENCIALPRESTAMO = precomcar.Secuencialprestamo,
                                    //               SECUENCIALCOMPONENTECARTERA = precomcar.Secuencialcomponentecartera,
                                    //               VALORPROYECTADO = precomcar.Valorproyectado,
                                    //               VALORCALCULADO = precomcar.Valorcalculado,
                                    //               VALORCOBRADO = precomcar.Valorcobrado,
                                    //               FECHAINICIO = precomcar.Fechainicio,
                                    //               FECHAVENCIMIENTO = precomcar.Fechavencimiento,
                                    //               NUMEROCUOTA = precomcar.Numerocuota,
                                    //               CODIGOESTADOPRESTAMOCOMPONENTE = precomcar.Codigoestadoprestamocomponente,
                                    //               FACTORCALCULO = precomcar.Factorcalculo,
                                    //               DIASCALCULADOS = precomcar.Diascalculados
                                    //           }).ToList(),
                                    _CALIFICACIONPRESTAMOS = null
                                    //_CALIFICACIONPRESTAMOS = (from calpre in context.Calificacionprestamo
                                    //                          where calpre.Secuencialprestamo == prema.Secuencial
                                    //                          select new CalificacionPrestamos
                                    //                          {
                                    //                              SECUENCIAL = calpre.Secuencial,
                                    //                              SECUENCIALPRESTAMO = calpre.Secuencialprestamo,
                                    //                              DIASMOROSIDAD = calpre.Diasmorosidad,
                                    //                              SALDOPRESTAMO = calpre.Saldoprestamo,
                                    //                              SECUENCIALCONDICIONCALIFAUT = calpre.Secuencialcondicioncalifaut,
                                    //                              SECUENCIALCONDICIONCALIFMANUAL = calpre.Secuencialcondicioncalifmanual,
                                    //                              PROVISIONAUTOMATICA = calpre.Provisionautomatica,
                                    //                              PROVISIONMANUAL = calpre.Provisionmanual,
                                    //                              PROVISIONCONSTITUIDA = calpre.Provisionconstituida,
                                    //                              CODIGOUSUARIO = calpre.Codigousuario,
                                    //                              FECHACALIFICACION = calpre.Fechacalificacion,
                                    //                              FECHAMAQUINA = calpre.Fechamaquina,
                                    //                              NUMEROVERIFICADOR = calpre.Numeroverificador,
                                    //                              ESHOMOLOGADA = calpre.Eshomologada,
                                    //                              PROVISIONORIGINAL = calpre.Provisionoriginal,
                                    //                              SECUENCIALCONDCALIFAUTORIGINAL = calpre.Secuencialcondcalifautoriginal
                                    //                          }).ToList()
                                }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
            }
            return clientesMora;
        }

        public ClienteDetalleCredito GetClienteDetalleCredito(string credito)
        {
            ClienteDetalleCredito detalleCredito = new ClienteDetalleCredito();
            try
            {
                detalleCredito = (from prema in context.Prestamomaestro
                                  join pc in context.Prestamocliente on prema.Secuencial equals pc.Secuencialprestamo
                                  join clie in context.Cliente on pc.Secuencialcliente equals clie.Secuencial
                                  join per in context.Persona on clie.Secuencialpersona equals per.Secuencial
                                  where prema.Numeroprestamo == credito
                                  select new ClienteDetalleCredito
                                  {
                                      _PRESTAMOS = new PrestamoMaestros
                                      {
                                          SECUENCIAL = prema.Secuencial,
                                          NUMEROPRESTAMO = prema.Numeroprestamo,
                                          SECUENCIALEMPRESA = prema.Secuencialempresa,
                                          CODIGOTIPOPRESTAMO = prema.Codigotipoprestamo,
                                          CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                          SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                          SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                          CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                          FRECUENCIAPAGO = prema.Frecuenciapago,
                                          NUMEROCUOTAS = prema.Numerocuotas,
                                          DEUDAINICIAL = prema.Deudainicial,
                                          VALORENTREGADO = prema.Valorentregado,
                                          FECHAADJUDICACION = prema.Fechaadjudicacion,
                                          FECHAVENCIMIENTO = prema.Fechavencimiento,
                                          SECUENCIALMONEDA = prema.Secuencialmoneda,
                                          CODIGOESTADOPRESTAMO = prema.Codigoestadoprestamo,
                                          SALDOACTUAL = prema.Saldoactual,
                                          CALIFICACIONACTUAL = prema.Calificacionactual,
                                          CALIFICACIONPEOR = prema.Calificacionpeor,
                                          CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                          SECUENCIALOFICINA = prema.Secuencialoficina,
                                          COBRAPORROL = prema.Cobraporrol,
                                          SEREAJUSTA = prema.Sereajusta,
                                          DIASREAJUSTE = prema.Diasreajuste,
                                          FECHACORTE = prema.Fechacorte,
                                          TEACONSEGURO = prema.Teaconseguro,
                                          TEASINSEGURO = prema.Teasinseguro,
                                          ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                          BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                          NUMEROPAGARE = prema.Numeropagare,
                                          IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                          NUMEROVERIFICADOR = prema.Numeroverificador,
                                          _PRESTAMOCLIENTES = (from preclie in context.Prestamocliente
                                                               where preclie.Secuencialprestamo == prema.Secuencial
                                                               select new PrestamoClientes
                                                               {
                                                                   SECUENCIAL = preclie.Secuencial,
                                                                   SECUENCIALPRESTAMO = preclie.Secuencialprestamo,
                                                                   SECUENCIALCLIENTE = preclie.Secuencialcliente,
                                                                   ESPRINCIPAL = preclie.Esprincipal,
                                                                   ESTAACTIVO = preclie.Estaactivo,
                                                                   NUMEROVERIFICADOR = preclie.Numeroverificador,
                                                                   _MOVIMIENTOS = (from movdet in context.MovimientodetallePrestamocli
                                                                                   where movdet.Secuencialprestamocliente == preclie.Secuencial
                                                                                   select new MoviemientoDetalle_PrestamoCli
                                                                                   {
                                                                                       SECUENCIAL = movdet.Secuencial,
                                                                                       SECUENCIALMOVDETALLEPRESTAMO = movdet.Secuencialmovdetalleprestamo,
                                                                                       SECUENCIALPRESTAMOCLIENTE = movdet.Secuencialprestamocliente,
                                                                                       VALOR = movdet.Valor
                                                                                   }).ToList()
                                                               }).ToList(),
                                          _SALDOS = (from precomcar in context.PrestamocomponenteCartera
                                                     where precomcar.Secuencialprestamo == prema.Secuencial
                                                     select new PrestamoComponente_Carteras
                                                     {
                                                         SECUENCIAL = precomcar.Secuencial,
                                                         SECUENCIALPRESTAMO = precomcar.Secuencialprestamo,
                                                         SECUENCIALCOMPONENTECARTERA = precomcar.Secuencialcomponentecartera,
                                                         VALORPROYECTADO = precomcar.Valorproyectado,
                                                         VALORCALCULADO = precomcar.Valorcalculado,
                                                         VALORCOBRADO = precomcar.Valorcobrado,
                                                         FECHAINICIO = precomcar.Fechainicio,
                                                         FECHAVENCIMIENTO = precomcar.Fechavencimiento,
                                                         NUMEROCUOTA = precomcar.Numerocuota,
                                                         CODIGOESTADOPRESTAMOCOMPONENTE = precomcar.Codigoestadoprestamocomponente,
                                                         FACTORCALCULO = precomcar.Factorcalculo,
                                                         DIASCALCULADOS = precomcar.Diascalculados
                                                     }).ToList(),
                                          _CALIFICACIONPRESTAMOS = (from calpre in context.Calificacionprestamo
                                                                    where calpre.Secuencialprestamo == prema.Secuencial
                                                                    select new CalificacionPrestamos
                                                                    {
                                                                        SECUENCIAL = calpre.Secuencial,
                                                                        SECUENCIALPRESTAMO = calpre.Secuencialprestamo,
                                                                        DIASMOROSIDAD = calpre.Diasmorosidad,
                                                                        SALDOPRESTAMO = calpre.Saldoprestamo,
                                                                        SECUENCIALCONDICIONCALIFAUT = calpre.Secuencialcondicioncalifaut,
                                                                        SECUENCIALCONDICIONCALIFMANUAL = calpre.Secuencialcondicioncalifmanual,
                                                                        PROVISIONAUTOMATICA = calpre.Provisionautomatica,
                                                                        PROVISIONMANUAL = calpre.Provisionmanual,
                                                                        PROVISIONCONSTITUIDA = calpre.Provisionconstituida,
                                                                        CODIGOUSUARIO = calpre.Codigousuario,
                                                                        FECHACALIFICACION = calpre.Fechacalificacion,
                                                                        FECHACALIFICACION_MES_ANO = calpre.Fechacalificacion.ToString("MM/yyyy"),
                                                                        FECHAMAQUINA = calpre.Fechamaquina,
                                                                        NUMEROVERIFICADOR = calpre.Numeroverificador,
                                                                        ESHOMOLOGADA = calpre.Eshomologada,
                                                                        PROVISIONORIGINAL = calpre.Provisionoriginal,
                                                                        SECUENCIALCONDCALIFAUTORIGINAL = calpre.Secuencialcondcalifautoriginal
                                                                    }).ToList()
                                      },
                                      _CLIENTE = new Clientes
                                      {
                                          SECUENCIAL = clie.Secuencial,
                                          SECUENCIALOFICINA = clie.Secuencialoficina,
                                          SECUENCIALPERSONA = clie.Secuencialpersona,
                                          NUMEROCLIENTE = clie.Numerocliente,
                                          FECHAINGRESO = clie.Fechaingreso,
                                          CODIGOUSUARIOOFICIAL = clie.Codigousuariooficial,
                                          CODIGOSECTORECONOMICO = clie.Codigosectoreconomico,
                                          CODIGOTIPOVINCULACION = clie.Codigotipovinculacion,
                                          CODIGOCALIFICACIONINTERNA = clie.Codigocalificacioninterna,
                                          SECUENCIALDIVISIONMERCADO = clie.Secuencialdivisionmercado,
                                          CODIGOESTADOCLIENTE = clie.Codigoestadocliente,
                                          NUMEROVERIFICADOR = clie.Numeroverificador
                                      },
                                      _PERSONA = new Personas
                                      {
                                          SECUENCIAL = per.Secuencial,
                                          IDENTIFICACION = per.Identificacion,
                                          NOMBREUNIDO = per.Nombreunido,
                                          DIRECCIONDOMICILIO = per.Direcciondomicilio,
                                          REFERENCIADOMICILIARIA = per.Referenciadomiciliaria,
                                          EMAIL = per.Email,
                                          SECUENCIALTIPOIDENTIFICACION = per.Secuencialtipoidentificacion,
                                          SECUENCIALDIVPOLRESIDENCIA = per.Secuencialdivpolresidencia,
                                          CODIGOPAISORIGEN = per.Codigopaisorigen,
                                          NUMEROVERIFICADOR = per.Numeroverificador,
                                          SECUENCIALDIVACTIVIDADECON = per.Secuencialdivactividadecon,
                                          CODIGOSOCIOMIGRA = per.Codigosociomigra.Trim(),
                                          IDENTIFICACIONMIGRA = per.Identificacionmigra,
                                      }
                                  }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                detalleCredito = null;
            }
            return detalleCredito;
        }

        public Mora GetMora(int secuencial)
        {
            string qry = string.Empty;
            Mora items = new Mora();
            try
            {
                qry = "SELECT SUM(VALORCALCULADO) AS TOTALVALORCALCULADO, COUNT(SECUENCIAL) AS CUOTASVENCIDAS, DATEDIFF(DAY, (select top (1) FECHA from FBS_NEGOCIOSFINANCIEROS.FECHACIERREETAPA order by fecha desc), GETDATE()) AS DIASDEMORA";
                qry += " FROM FBS_CARTERA.PRESTAMOCOMPONENTE_CARTERA";
                qry += " WHERE(SECUENCIALPRESTAMO =" + secuencial + ") AND(CODIGOESTADOPRESTAMOCOMPONENTE = 'V') AND(SECUENCIALCOMPONENTECARTERA = 44)";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            items.VALORCALCULADO = dr.GetDecimal(0);
                            items.CUOTASVENCIDAS = dr.GetInt32(1);
                            items.DIASDEMORA = dr.GetInt32(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                items = null;
            }

            return items;
        }

        public ClienteConsolidado CuentasCliente(string identificacion)
        {
            ClienteConsolidado extend = new ClienteConsolidado();
            List<ClienteCuentas> _cuentas = new List<ClienteCuentas>();
            string qry = string.Empty;

            try
            {
                _cuentas = GetClienteCuentas(identificacion);

                extend.Identificacion = identificacion;
                extend.NombreUnido = (_cuentas.Count > 0) ? _cuentas.FirstOrDefault().NombreUnido.ToString() : context.Persona.FirstOrDefault(a => a.Identificacion == identificacion).Nombreunido;
                extend.Cuentas = _cuentas;
                extend.Prestamos = (_cuentas.Count > 0) ? GetPrestamos(Convert.ToInt32(_cuentas.FirstOrDefault().SecuencialCliente)) : null;
                extend.DspositoPF = GetMovimientoCuentasDPF(identificacion);
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                extend = null;
            }
            return extend;
        }

        /// <summary>
        /// Metodo para obtener los movimientos de una cuenta
        /// </summary>
        /// <param name="secuencial">secuecial de cuenta</param>
        /// <returns></returns>
        public List<ClienteCuentaMovimientos> GetMovimientoCuentas(int secuencial)
        {
            List<ClienteCuentaMovimientos> extend = new List<ClienteCuentaMovimientos>();
            string qry = string.Empty;

            var mesactual = DateTime.Now.ToString("MM");
            var anoactual = DateTime.Now.ToString("yyyy");

            var fechaInicio = "01/" + mesactual + "/" + anoactual;
            var fehaFin = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");


            try
            {
                #region COMMENT

                //qry = "SELECT ";
                //qry += "CM.CODIGOTIPOCUENTA, ";
                //qry += "CM.CODIGO, ";
                //qry += "CODIGOUSUARIO, ";
                //qry += " C.NUMEROCLIENTE, ";
                //qry += "P.IDENTIFICACION, ";
                //qry += "NOMBREUNIDO, ";
                //qry += "MD.VALOR, ";
                //qry += "T.NOMBRE, ";
                //qry += "M.FECHA, ";
                //qry += "M.SECUENCIAL, ";
                //qry += "MDC.SECUENCIALMOVIMIENTODETALLE, ";
                //qry += "T.SECUENCIAL, ";
                //qry += "M.DOCUMENTO, ";
                //qry += "MDC.SALDOCUENTA, ";
                //qry += "cm.CODIGOESTADO, ";
                //qry += "ec.NOMBRE, ";
                //qry += "tc.NOMBRE as NOMBRETIPOCUENTA ";
                //qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cm ";
                //qry += "join FBS_CAPTACIONESVISTA.ESTADOCUENTA ec on cm.CODIGOESTADO = ec.CODIGO ";
                //qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
                //qry += "join FBS_CAPTACIONESVISTA.TIPOCUENTA tc on tc.CODIGO = cm.CODIGOTIPOCUENTA ";
                //qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
                //qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
                //qry += "JOIN FBS_PERSONAS.TIPOIDENTIFICACION TP ON TP.SECUENCIAL = P.SECUENCIALTIPOIDENTIFICACION ";
                //qry += "JOIN FBS_CAPTACIONESVISTA.CUENTACOMPONENTE_VISTA CCV  ON CM.SECUENCIAL = CCV.SECUENCIALCUENTA ";
                //qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
                //qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTODETALLE MD ON MD.SECUENCIAL = MDC.SECUENCIALMOVIMIENTODETALLE ";
                //qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO M ON M.SECUENCIAL = MD.SECUENCIALMOVIMIENTO ";
                //qry += "JOIN FBS_NEGOCIOSFINANCIEROS.TRANSACCION T ON T.SECUENCIAL = MD.SECUENCIALTRANSACCION ";
                //qry += "WHERE cm.SECUENCIAL = '" + secuencial + "' and M.FECHA BETWEEN  '01/04/2015' and '31/12/2020' ";
                //qry += "group BY cm.CODIGOESTADO, CM.CODIGOTIPOCUENTA,CM.CODIGO, CODIGOUSUARIO, C.NUMEROCLIENTE , P.IDENTIFICACION,NOMBREUNIDO,MD.VALOR,T.NOMBRE,M.FECHA,M.SECUENCIAL,MDC.SECUENCIALMOVIMIENTODETALLE,T.SECUENCIAL,M.DOCUMENTO,MDC.SALDOCUENTA, ec.NOMBRE, tc.NOMBRE ";
                //qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE";

                #endregion COMMENT

                qry = "SELECT ";
                qry += "CM.CODIGOTIPOCUENTA, ";
                qry += "CM.CODIGO, ";
                qry += "CODIGOUSUARIO, ";
                qry += " C.NUMEROCLIENTE, ";
                qry += "P.IDENTIFICACION, ";
                qry += "NOMBREUNIDO, ";
                qry += "MD.VALOR, ";
                qry += "T.NOMBRE, ";
                qry += "M.FECHA, ";
                qry += "M.SECUENCIAL, ";
                qry += "MDC.SECUENCIALMOVIMIENTODETALLE, ";
                qry += "T.SECUENCIAL, ";
                qry += "M.DOCUMENTO, ";
                qry += "MDC.SALDOCUENTA, ";
                qry += "cm.CODIGOESTADO, ";
                qry += "ec.NOMBRE, ";
                qry += "tc.NOMBRE as NOMBRETIPOCUENTA ";
                qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cm ";
                qry += "join FBS_CAPTACIONESVISTA.ESTADOCUENTA ec on cm.CODIGOESTADO = ec.CODIGO ";
                qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
                qry += "join FBS_CAPTACIONESVISTA.TIPOCUENTA tc on tc.CODIGO = cm.CODIGOTIPOCUENTA ";
                qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
                qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "JOIN FBS_PERSONAS.TIPOIDENTIFICACION TP ON TP.SECUENCIAL = P.SECUENCIALTIPOIDENTIFICACION ";
                qry += "JOIN FBS_CAPTACIONESVISTA.CUENTACOMPONENTE_VISTA CCV  ON CM.SECUENCIAL = CCV.SECUENCIALCUENTA ";
                qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTODETALLE MD ON MD.SECUENCIAL = MDC.SECUENCIALMOVIMIENTODETALLE ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO M ON M.SECUENCIAL = MD.SECUENCIALMOVIMIENTO ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.TRANSACCION T ON T.SECUENCIAL = MD.SECUENCIALTRANSACCION ";
                qry += "WHERE cm.SECUENCIAL = '" + secuencial + "' and M.FECHA BETWEEN  '" + fechaInicio + "' and '" + fehaFin + "' ";
                qry += "group BY cm.CODIGOESTADO, CM.CODIGOTIPOCUENTA,CM.CODIGO, CODIGOUSUARIO, C.NUMEROCLIENTE , P.IDENTIFICACION,NOMBREUNIDO,MD.VALOR,T.NOMBRE,M.FECHA,M.SECUENCIAL,MDC.SECUENCIALMOVIMIENTODETALLE,T.SECUENCIAL,M.DOCUMENTO,MDC.SALDOCUENTA, ec.NOMBRE, tc.NOMBRE ";
                qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            extend.Add(new ClienteCuentaMovimientos
                            {
                                CodigoTipocuenta = c.GetString(0),
                                CodigoCuentaMaestro = c.GetString(1),
                                CodigoUsuario = c.GetString(2),
                                NumeroCliente = c.GetInt32(3),
                                Identificacion = c.GetString(4),
                                NombreUnido = c.GetString(5),
                                Valor = c.GetDecimal(6),
                                NombreTransacion = c.GetString(7),
                                Fecha = c.GetDateTime(8),
                                SecuencialMovimiento = c.GetInt32(9),
                                SecuencialMovimientoDetalle = c.GetInt32(10),
                                Secuencialtransaccion = c.GetInt32(11),
                                Documento = c.GetString(12),
                                SaldoCuenta = c.GetDecimal(13),
                                CodigoEstado = c.GetString(14),
                                NombreEstado = c.GetString(15),
                                NombreTipoCuenta = c.GetString(16),
                            });
                        }
                    }
                    else
                        extend = null;

                    //List<ClienteCuentaMovimientos> extendList = GetMovimientoCuentas(extend, secuencial);
                    //if (extendList.Any())
                    //    extend = extendList;
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                extend = null;
            }
            return extend;
        }

        /// <summary>
        /// Metodo para obtener los movimientos de una cuenta
        /// </summary>
        /// <param name="secuencial">secuencial de cuenta</param>
        /// <param name="mes">mes de movimiento</param>
        /// <date>27-06-2018>date>
        /// <author>Miguel Patiño</author>
        /// <returns></returns>
        public List<ClienteCuentaMovimientos> GetMovimientoCuentasByIdAndMonth(int secuencial, string mes)
        {
            List<ClienteCuentaMovimientos> extend = new List<ClienteCuentaMovimientos>();
            string qry = string.Empty;

            var lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(mes));

            var fechaInicio = "01/" + mes + "/" + DateTime.Now.Year.ToString();
            var fehaFin = lastDayOfMonth + "/" + mes + "/" + DateTime.Now.Year.ToString();

            try
            {
                qry = "SELECT ";
                qry += "CM.CODIGOTIPOCUENTA, ";
                qry += "CM.CODIGO, ";
                qry += "CODIGOUSUARIO, ";
                qry += " C.NUMEROCLIENTE, ";
                qry += "P.IDENTIFICACION, ";
                qry += "NOMBREUNIDO, ";
                qry += "MD.VALOR, ";
                qry += "T.NOMBRE, ";
                qry += "M.FECHA, ";
                qry += "M.SECUENCIAL, ";
                qry += "MDC.SECUENCIALMOVIMIENTODETALLE, ";
                qry += "T.SECUENCIAL, ";
                qry += "M.DOCUMENTO, ";
                qry += "MDC.SALDOCUENTA, ";
                qry += "cm.CODIGOESTADO, ";
                qry += "ec.NOMBRE, ";
                qry += "tc.NOMBRE as NOMBRETIPOCUENTA ";
                qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cm ";
                qry += "join FBS_CAPTACIONESVISTA.ESTADOCUENTA ec on cm.CODIGOESTADO = ec.CODIGO ";
                qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
                qry += "join FBS_CAPTACIONESVISTA.TIPOCUENTA tc on tc.CODIGO = cm.CODIGOTIPOCUENTA ";
                qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
                qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "JOIN FBS_PERSONAS.TIPOIDENTIFICACION TP ON TP.SECUENCIAL = P.SECUENCIALTIPOIDENTIFICACION ";
                qry += "JOIN FBS_CAPTACIONESVISTA.CUENTACOMPONENTE_VISTA CCV  ON CM.SECUENCIAL = CCV.SECUENCIALCUENTA ";
                qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTODETALLE MD ON MD.SECUENCIAL = MDC.SECUENCIALMOVIMIENTODETALLE ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO M ON M.SECUENCIAL = MD.SECUENCIALMOVIMIENTO ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.TRANSACCION T ON T.SECUENCIAL = MD.SECUENCIALTRANSACCION ";
                qry += "WHERE cm.SECUENCIAL = '" + secuencial + "' and M.FECHA BETWEEN  '" + fechaInicio + "' and '" + fehaFin + "' ";
                qry += "group BY cm.CODIGOESTADO, CM.CODIGOTIPOCUENTA,CM.CODIGO, CODIGOUSUARIO, C.NUMEROCLIENTE , P.IDENTIFICACION,NOMBREUNIDO,MD.VALOR,T.NOMBRE,M.FECHA,M.SECUENCIAL,MDC.SECUENCIALMOVIMIENTODETALLE,T.SECUENCIAL,M.DOCUMENTO,MDC.SALDOCUENTA, ec.NOMBRE, tc.NOMBRE ";
                qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            extend.Add(new ClienteCuentaMovimientos
                            {
                                CodigoTipocuenta = c.GetString(0),
                                CodigoCuentaMaestro = c.GetString(1),
                                CodigoUsuario = c.GetString(2),
                                NumeroCliente = c.GetInt32(3),
                                Identificacion = c.GetString(4),
                                NombreUnido = c.GetString(5),
                                Valor = c.GetDecimal(6),
                                NombreTransacion = c.GetString(7),
                                Fecha = c.GetDateTime(8),
                                SecuencialMovimiento = c.GetInt32(9),
                                SecuencialMovimientoDetalle = c.GetInt32(10),
                                Secuencialtransaccion = c.GetInt32(11),
                                Documento = c.GetString(12),
                                SaldoCuenta = c.GetDecimal(13),
                                CodigoEstado = c.GetString(14),
                                NombreEstado = c.GetString(15),
                                NombreTipoCuenta = c.GetString(16),
                            });
                        }
                    }
                    else
                        extend = null;

                    //List<ClienteCuentaMovimientos> extendList = GetMovimientoCuentas(extend, secuencial);
                    //if (extendList.Any())
                    //    extend = extendList;
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                extend = null;
            }
            return extend;
        }

        public List<ClienteCuentaMovimientos> GetMovimientoCuentasByIdAndRange(int secuencial, string mesIni, string mesFin)
        {
            List<ClienteCuentaMovimientos> extend = new List<ClienteCuentaMovimientos>();
            string qry = string.Empty;

            DateTime fecfin = Convert.ToDateTime(mesFin);

            try
            {
                qry = "SELECT ";
                qry += "CM.CODIGOTIPOCUENTA, ";
                qry += "CM.CODIGO, ";
                qry += "CODIGOUSUARIO, ";
                qry += " C.NUMEROCLIENTE, ";
                qry += "P.IDENTIFICACION, ";
                qry += "NOMBREUNIDO, ";
                qry += "MD.VALOR, ";
                qry += "T.NOMBRE, ";
                qry += "M.FECHA, ";
                qry += "M.SECUENCIAL, ";
                qry += "MDC.SECUENCIALMOVIMIENTODETALLE, ";
                qry += "T.SECUENCIAL, ";
                qry += "M.DOCUMENTO, ";
                qry += "MDC.SALDOCUENTA, ";
                qry += "cm.CODIGOESTADO, ";
                qry += "ec.NOMBRE, ";
                qry += "tc.NOMBRE as NOMBRETIPOCUENTA ";
                qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cm ";
                qry += "join FBS_CAPTACIONESVISTA.ESTADOCUENTA ec on cm.CODIGOESTADO = ec.CODIGO ";
                qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
                qry += "join FBS_CAPTACIONESVISTA.TIPOCUENTA tc on tc.CODIGO = cm.CODIGOTIPOCUENTA ";
                qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
                qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "JOIN FBS_PERSONAS.TIPOIDENTIFICACION TP ON TP.SECUENCIAL = P.SECUENCIALTIPOIDENTIFICACION ";
                qry += "JOIN FBS_CAPTACIONESVISTA.CUENTACOMPONENTE_VISTA CCV  ON CM.SECUENCIAL = CCV.SECUENCIALCUENTA ";
                qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTODETALLE MD ON MD.SECUENCIAL = MDC.SECUENCIALMOVIMIENTODETALLE ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO M ON M.SECUENCIAL = MD.SECUENCIALMOVIMIENTO ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.TRANSACCION T ON T.SECUENCIAL = MD.SECUENCIALTRANSACCION ";
                qry += "WHERE cm.SECUENCIAL = '" + secuencial + "' and M.FECHA BETWEEN  '" + mesIni + "' and '" + fecfin.AddDays(1) + "' ";
                qry += "group BY cm.CODIGOESTADO, CM.CODIGOTIPOCUENTA,CM.CODIGO, CODIGOUSUARIO, C.NUMEROCLIENTE , P.IDENTIFICACION,NOMBREUNIDO,MD.VALOR,T.NOMBRE,M.FECHA,M.SECUENCIAL,MDC.SECUENCIALMOVIMIENTODETALLE,T.SECUENCIAL,M.DOCUMENTO,MDC.SALDOCUENTA, ec.NOMBRE, tc.NOMBRE ";
                qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            extend.Add(new ClienteCuentaMovimientos
                            {
                                CodigoTipocuenta = c.GetString(0),
                                CodigoCuentaMaestro = c.GetString(1),
                                CodigoUsuario = c.GetString(2),
                                NumeroCliente = c.GetInt32(3),
                                Identificacion = c.GetString(4),
                                NombreUnido = c.GetString(5),
                                Valor = c.GetDecimal(6),
                                NombreTransacion = c.GetString(7),
                                Fecha = c.GetDateTime(8),
                                SecuencialMovimiento = c.GetInt32(9),
                                SecuencialMovimientoDetalle = c.GetInt32(10),
                                Secuencialtransaccion = c.GetInt32(11),
                                Documento = c.GetString(12),
                                SaldoCuenta = c.GetDecimal(13),
                                CodigoEstado = c.GetString(14),
                                NombreEstado = c.GetString(15),
                                NombreTipoCuenta = c.GetString(16),
                            });
                        }
                    }
                    else
                        extend = null;
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                extend = null;
            }
            return extend;
        }

        public List<PrestamoMaestros> GetPrestamos(int secuencialCliente)
        {
            List<PrestamoMaestros> _PrestamosMaestros = new List<PrestamoMaestros>();
            try
            {
                _PrestamosMaestros = (from c in context.Cliente
                                      join pc in context.Prestamocliente on c.Secuencial equals pc.Secuencialcliente
                                      join prema in context.Prestamomaestro on pc.Secuencialprestamo equals prema.Secuencial
                                      join tp in context.TipoPrestamo on prema.Codigotipoprestamo equals tp.Codigo
                                      join ep in context.Estadoprestamo on prema.Codigoestadoprestamo equals ep.Codigo
                                      where c.Secuencial == secuencialCliente
                                      select new PrestamoMaestros
                                      {
                                          SECUENCIAL = prema.Secuencial,
                                          NUMEROPRESTAMO = prema.Numeroprestamo,
                                          SECUENCIALEMPRESA = prema.Secuencialempresa,
                                          CODIGOTIPOPRESTAMO = tp.Nombre, //prema.Codigotipoprestamo,
                                          CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                          SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                          SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                          CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                          FRECUENCIAPAGO = prema.Frecuenciapago,
                                          NUMEROCUOTAS = prema.Numerocuotas,
                                          DEUDAINICIAL = prema.Deudainicial,
                                          VALORENTREGADO = prema.Valorentregado,
                                          FECHAADJUDICACION = prema.Fechaadjudicacion,
                                          FECHAVENCIMIENTO = prema.Fechavencimiento,
                                          SECUENCIALMONEDA = prema.Secuencialmoneda,
                                          CODIGOESTADOPRESTAMO = ep.Nombre, // prema.Codigoestadoprestamo,
                                          SALDOACTUAL = prema.Saldoactual,
                                          CALIFICACIONACTUAL = prema.Calificacionactual,
                                          CALIFICACIONPEOR = prema.Calificacionpeor,
                                          CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                          SECUENCIALOFICINA = prema.Secuencialoficina,
                                          COBRAPORROL = prema.Cobraporrol,
                                          SEREAJUSTA = prema.Sereajusta,
                                          DIASREAJUSTE = prema.Diasreajuste,
                                          FECHACORTE = prema.Fechacorte,
                                          TEACONSEGURO = prema.Teaconseguro,
                                          TEASINSEGURO = prema.Teasinseguro,
                                          ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                          BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                          NUMEROPAGARE = prema.Numeropagare,
                                          IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                          NUMEROVERIFICADOR = prema.Numeroverificador
                                      }).ToList();
                //_PrestamosMaestros = (from prema in context.Prestamomaestro
                //                      join tp in context.TipoPrestamo on prema.Codigotipoprestamo equals tp.Codigo
                //                      join ep in context.Estadoprestamo on prema.Codigoestadoprestamo equals ep.Codigo
                //                      where prema.Codigousuariooficial == codigo
                //                      select new PrestamoMaestros
                //                      {
                //                          SECUENCIAL = prema.Secuencial,
                //                          NUMEROPRESTAMO = prema.Numeroprestamo,
                //                          SECUENCIALEMPRESA = prema.Secuencialempresa,
                //                          CODIGOTIPOPRESTAMO = tp.Nombre, //prema.Codigotipoprestamo,
                //                          CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                //                          SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                //                          SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                //                          CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                //                          FRECUENCIAPAGO = prema.Frecuenciapago,
                //                          NUMEROCUOTAS = prema.Numerocuotas,
                //                          DEUDAINICIAL = prema.Deudainicial,
                //                          VALORENTREGADO = prema.Valorentregado,
                //                          FECHAADJUDICACION = prema.Fechaadjudicacion,
                //                          FECHAVENCIMIENTO = prema.Fechavencimiento,
                //                          SECUENCIALMONEDA = prema.Secuencialmoneda,
                //                          CODIGOESTADOPRESTAMO = ep.Nombre, // prema.Codigoestadoprestamo,
                //                          SALDOACTUAL = prema.Saldoactual,
                //                          CALIFICACIONACTUAL = prema.Calificacionactual,
                //                          CALIFICACIONPEOR = prema.Calificacionpeor,
                //                          CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                //                          SECUENCIALOFICINA = prema.Secuencialoficina,
                //                          COBRAPORROL = prema.Cobraporrol,
                //                          SEREAJUSTA = prema.Sereajusta,
                //                          DIASREAJUSTE = prema.Diasreajuste,
                //                          FECHACORTE = prema.Fechacorte,
                //                          TEACONSEGURO = prema.Teaconseguro,
                //                          TEASINSEGURO = prema.Teasinseguro,
                //                          ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                //                          BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                //                          NUMEROPAGARE = prema.Numeropagare,
                //                          IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                //                          NUMEROVERIFICADOR = prema.Numeroverificador
                //                      }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                _PrestamosMaestros = null;
            }
            return _PrestamosMaestros;
        }

        public List<PrestamosMovimientos> GetMovimientosPrestamos(int secuencialPrestamo)
        {
            List<PrestamosMovimientos> list = new List<PrestamosMovimientos>();

            string qry = string.Empty;

            try
            {
                qry = "SELECT MPC_C.SECUENCIAL, ";
                qry += "MPC_C.SECUENCIALMOVIMIENTODETALLE, ";
                qry += "MPC_C.SECUENCIALPRESTAMO, ";
                qry += "MPC_C.SECUENCIALCOMPONENTECARTERA, ";
                qry += "MPC_C.CODIGOTIPOMOVIMIENTO, ";
                qry += "MPC_C.NUMEROCUOTA,";
                qry += "TCC.NOMBRE AS NOMRECOMPONENTE, ";
                qry += " MPC_C.VALOR, ";
                qry += "MPC_C.SALDO,";
                qry += "MPC_C.CODIGOESTADOPRESTAMOCOMPONENTE,";
                qry += "EPC_C.CODIGO,";
                qry += "EPC_C.NOMBRE,";
                qry += "M.FECHA, ";
                qry += "MD_P.SALDOPRESTAMO, ";
                qry += "MD_PC.VALOR AS VALORMOVIEMIENTODETALLEPRESTAMOCLI, ";
                qry += "PM.NUMEROPRESTAMO ";
                qry += "FROM FBS_CARTERA.MOVIMIENTOPRESTAMOCOMP_CAR AS MPC_C left OUTER JOIN ";
                qry += "FBS_CARTERA.COMPONENTE_CARTERA AS CC ON MPC_C.SECUENCIALCOMPONENTECARTERA = CC.SECUENCIALCOMPONENTE left OUTER JOIN ";
                qry += "FBS_CARTERA.ESTADOPRESTAMOCOMPONENTE_CAR AS EPC_C ON MPC_C.CODIGOESTADOPRESTAMOCOMPONENTE = EPC_C.CODIGO left OUTER JOIN ";
                qry += "FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO AS M ON MPC_C.SECUENCIAL = M.SECUENCIAL left OUTER JOIN ";
                qry += "FBS_CARTERA.MOVIMIENTODETALLE_PRESTAMO MD_P ON MPC_C.SECUENCIALMOVIMIENTODETALLE = MD_P.SECUENCIALMOVIMIENTODETALLE left OUTER JOIN ";
                qry += "FBS_CARTERA.MOVIMIENTODETALLE_PRESTAMOCLI MD_PC ON MD_PC.SECUENCIALMOVDETALLEPRESTAMO = MD_P.SECUENCIALMOVIMIENTODETALLE AND ";
                qry += "MD_PC.SECUENCIALMOVDETALLEPRESTAMO = MD_P.SECUENCIALMOVIMIENTODETALLE INNER JOIN ";
                qry += "FBS_CARTERA.TIPOCOMPONENTECARTERA as TCC ON CC.SECUENCIALTIPOCOMPONENTECAR = TCC.SECUENCIAL AND ";
                qry += "CC.SECUENCIALTIPOCOMPONENTECAR = TCC.SECUENCIAL INNER JOIN ";
                qry += "FBS_CARTERA.PRESTAMOMAESTRO as PM ON MPC_C.SECUENCIALPRESTAMO = PM.SECUENCIAL AND MPC_C.SECUENCIALPRESTAMO = PM.SECUENCIAL ";
                qry += "WHERE(MPC_C.SECUENCIALPRESTAMO = '" + secuencialPrestamo + "') ";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            list.Add(new PrestamosMovimientos
                            {
                                Secuencial = c.GetInt32(0),
                                SecuencialMovimientoDetalle = c.GetInt32(1),
                                SecuencialPrestamo = c.GetInt32(2),
                                SecuencialComponenteCartera = c.GetInt32(3),
                                CodigoTipoMovimiento = c.GetString(4),
                                Numerocuota = c.GetInt32(5),
                                NombreComponente = c.GetString(6),
                                Valor = c.GetDecimal(7),
                                Saldo = c.GetDecimal(8),
                                CodigoEstadoPrestamoComponente = c.GetString(9),
                                Codigo = c.GetString(10),
                                Nombre = c.GetString(11),
                                Fecha = c.IsDBNull(12) ? Convert.ToDateTime("01/01/1999") : c.GetDateTime(12),
                                SaldoPrestamo = c.IsDBNull(13) ? 0 : c.GetDecimal(13),  //(c.GetDecimal(13)),
                                ValorMovimientoDetalle = c.IsDBNull(14) ? 0 : c.GetDecimal(14),  //c.GetDecimal(14),
                                NumeroPrestamo = c.GetString(15)
                            });
                        }
                    }
                    else
                        list = null;
                }

                //list = (from mdp in context.Movimientodetalleprestamo
                //        join ep in context.Estadoprestamo on mdp.Codigoestadoprestamo equals ep.Codigo
                //        where mdp.Secuencialprestamo == secuencialPrestamo
                //        select new PrestamosMovimientos
                //        {
                //            SecuencialMovimiento = mdp.Secuencialmovimientodetalle,
                //            SecuencialPrestamo = mdp.Secuencialprestamo,
                //            SaldoPrestamo = mdp.Saldoprestamo,
                //            CodigoEstadoPrestamo = mdp.Codigoestadoprestamo,
                //            EstadoPrestamo = ep.Nombre
                //        }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
            }
            return list;
        }

        public TransferenciaTercerosCuentas GetAfiliciacionesCuentasTerceros(string cliente)
        {
            TransferenciaTercerosCuentas transferencia = new TransferenciaTercerosCuentas();
            List<CuentasClienteAfiliacion> clienteAfiliacion = new List<CuentasClienteAfiliacion>();
            string qry = string.Empty;

            try
            {
                qry = "SELECT ";
                qry += "CM.CODIGO, ";
                qry += "CM.SECUENCIAL, ";
                qry += "TC.NOMBRE AS NOMBRETIPOCUENTA, ";
                qry += "CM.NUMEROLIBRETA, ";
                qry += "CC.SECUENCIAL AS SECUENCIALCUENTACLIENTE, ";
                qry += "CM.NUMEROLINEAIMPRIMELIBRETA, ";
                qry += "P.IDENTIFICACION, ";
                qry += "P.NOMBREUNIDO, ";
                qry += "C.SECUENCIAL AS SECUENCIALCLIENTE, ";
                qry += "AT.IdAfiliciacionCliente, ";
                qry += "AT.NombreAfiliacion ";
                qry += "FROM  FBS_CAPTACIONESVISTA.CUENTAMAESTRO AS CM INNER JOIN ";
                qry += "[AdminTransaccional].[dbo].[Afiliacion] AT ON CM.SECUENCIAL = AT.secuencialcuenta INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.CUENTACLIENTE AS CC ON CM.SECUENCIAL = CC.SECUENCIALCUENTA INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.TIPOCUENTA AS TC ON CM.CODIGOTIPOCUENTA = TC.CODIGO INNER JOIN ";
                qry += "FBS_CLIENTES.CLIENTE AS C ON CC.SECUENCIALCLIENTE = C.SECUENCIAL AND CC.SECUENCIALCLIENTE = C.SECUENCIAL INNER JOIN ";
                qry += "FBS_PERSONAS.PERSONA AS P ON C.SECUENCIALPERSONA = P.SECUENCIAL AND C.SECUENCIALPERSONA = P.SECUENCIAL AND ";
                qry += "C.SECUENCIALPERSONA = P.SECUENCIAL AND C.SECUENCIALPERSONA = P.SECUENCIAL AND ";
                qry += "C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "WHERE(AT.identificacionusuario = '" + cliente + "')  AND (CM.CODIGOESTADO = N'A') AND AT.EstaActivo = '1'";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            clienteAfiliacion.Add(new CuentasClienteAfiliacion
                            {
                                IdAfiliacion = c.GetInt32(9),
                                SecuencialCuenta = c.GetInt32(1),
                                Identificacion = c.GetString(6),
                                TipoCuenta = c.GetString(2),
                                Libreta = Convert.ToString(c.GetInt32(3)),
                                NombreUnido = c.GetString(7),
                                NombreAfiliado = c.GetString(10),
                                SecuencialCliente = c.GetInt32(8)
                            });
                        }
                    }
                }
                transferencia.CuentasCliente = GetClienteCuentas(cliente);
                transferencia.AfiliacionCliente = clienteAfiliacion;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                transferencia = null;
            }
            return transferencia;
        }

        public List<ClienteCuentas> GetClienteCuentas(string identificacion)
        {
            List<ClienteCuentas> _cuentas = new List<ClienteCuentas>();
            string qry = string.Empty;
            try
            {
                qry = "SELECT ";
                qry += "CM.CODIGO, ";
                qry += "CM.CODIGOTIPOCUENTA, ";
                qry += "CM.CODIGOPRODUCTOVISTA, ";
                qry += "CM.SECUENCIAL, ";
                qry += "TC.NOMBRE AS NOMBRETIPOCUENTA, ";
                qry += "CM.CODIGOESTADO, ";
                qry += "EC.NOMBRE AS NOMBREESTADOCUENTA, ";
                qry += "CM.NUMEROLIBRETA, ";
                qry += "CC.SECUENCIAL AS SECUENCIALCUENTACLIENTE, ";
                qry += "PV.USALIBRETA, ";
                qry += "PV.USACHEQUERA, ";
                qry += "CM.NUMEROLINEAIMPRIMELIBRETA, ";
                qry += "CM.TIENESEGUROACTIVO, ";
                qry += "P.IDENTIFICACION, ";
                qry += "P.NOMBREUNIDO, ";
                qry += "(SELECT top(1) ";
                qry += "MDC.SALDOCUENTA ";
                qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cmt ";
                qry += "join FBS_CAPTACIONESVISTA.ESTADOCUENTA ec on cm.CODIGOESTADO = ec.CODIGO ";
                qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
                qry += "join FBS_CAPTACIONESVISTA.TIPOCUENTA tc on tc.CODIGO = cmt.CODIGOTIPOCUENTA ";
                qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
                qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "JOIN FBS_PERSONAS.TIPOIDENTIFICACION TP ON TP.SECUENCIAL = P.SECUENCIALTIPOIDENTIFICACION ";
                qry += "JOIN FBS_CAPTACIONESVISTA.CUENTACOMPONENTE_VISTA CCV  ON CM.SECUENCIAL = CCV.SECUENCIALCUENTA ";
                qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTODETALLE MD ON MD.SECUENCIAL = MDC.SECUENCIALMOVIMIENTODETALLE ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.MOVIMIENTO M ON M.SECUENCIAL = MD.SECUENCIALMOVIMIENTO ";
                qry += "JOIN FBS_NEGOCIOSFINANCIEROS.TRANSACCION T ON T.SECUENCIAL = MD.SECUENCIALTRANSACCION ";
                qry += "WHERE cmt.SECUENCIAL = cm.SECUENCIAL ";
                qry += "group BY MDC.SECUENCIALMOVIMIENTODETALLE, MDC.SALDOCUENTA ";
                qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE desc)  SALDOCUENTA, ";
                qry += "C.SECUENCIAL AS SECUENCIALCLIENTE ";
                qry += "FROM  FBS_CAPTACIONESVISTA.CUENTAMAESTRO AS CM INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.CUENTACLIENTE AS CC ON CM.SECUENCIAL = CC.SECUENCIALCUENTA INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.TIPOCUENTA AS TC ON CM.CODIGOTIPOCUENTA = TC.CODIGO INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.ESTADOCUENTA AS EC ON CM.CODIGOESTADO = EC.CODIGO INNER JOIN ";
                qry += "FBS_NEGOCIOSFINANCIEROS.PRODUCTO_VISTA AS PV ON CM.CODIGOPRODUCTOVISTA = PV.CODIGOPRODUCTO INNER JOIN ";
                qry += "FBS_CLIENTES.CLIENTE AS C ON CC.SECUENCIALCLIENTE = C.SECUENCIAL AND CC.SECUENCIALCLIENTE = C.SECUENCIAL INNER JOIN ";
                qry += "FBS_PERSONAS.PERSONA AS P ON C.SECUENCIALPERSONA = P.SECUENCIAL AND C.SECUENCIALPERSONA = P.SECUENCIAL AND ";
                qry += "C.SECUENCIALPERSONA = P.SECUENCIAL AND C.SECUENCIALPERSONA = P.SECUENCIAL AND ";
                qry += "C.SECUENCIALPERSONA = P.SECUENCIAL ";
                qry += "WHERE(P.IDENTIFICACION = '" + identificacion + "') AND (CM.CODIGOESTADO = N'A')";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            //
                            //int _secuencialCuenta = c.GetInt32(3);
                            //decimal _saldoCuenta = 0;
                            //bool _tieneTransferencias = adminTransaccional.Transferencia.Any(a => a.SecuencialCuentacliente == _secuencialCuenta);
                            //if (_tieneTransferencias)
                            //{
                            //    _saldoCuenta = adminTransaccional.Transferencia.OrderByDescending(a => a.IdTransferencia).FirstOrDefault(a => a.SecuencialCuentacliente == _secuencialCuenta).SaldoCuenta;
                            //}
                            ////

                            _cuentas.Add(new ClienteCuentas
                            {
                                Codigo = c.GetString(0),
                                CodigoTipocuenta = c.GetString(1),
                                codigoProductoVista = c.GetString(2),
                                SecuencialCuentaMaestro = c.GetInt32(3),
                                NombreTipoCuenta = c.GetString(4),
                                CodigoEstadoCuenta = c.GetString(5),
                                NombreEstadoCuenta = c.GetString(6),
                                NumeroLibreta = c.GetInt32(7),
                                SecuencialCuentaCliente = c.GetInt32(8),
                                UsaLibreta = c.GetBoolean(9),
                                UsaChequera = c.GetBoolean(10),
                                NumeroLineaLibreta = c.GetInt32(11),
                                TieneSeguro = c.GetBoolean(12),
                                Identificacion = c.GetString(13),
                                NombreUnido = c.GetString(14),
                                SaldoCuenta = c.GetDecimal(15),  //c.GetDecimal(15),
                                SecuencialCliente = c.GetInt32(16)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                _cuentas = null;
            }
            return _cuentas;
        }

        public bool AddTransferencia(TransferenciaTercerosCuentas transferencia)
        {
            bool result = true;

            try
            {
                #region COMMENT

                //Random rdm = new Random();
                //int credito = 22; //TODO codigo tabla FBS_NEGOCIOSFINANCIEROS.TRANSACCION para nota de creditos
                //int debito = 23; //TODO codigo tabla FBS_NEGOCIOSFINANCIEROS.TRANSACCION para nota de debitos
                //string identificacionAfiliado = string.Empty;
                //int cuentaAfiliado = 0;
                //int _idAfiliacion = 0;

                //if (transferencia.TipoTransferencia == 1) //Terceros
                //{
                //    var usuarioAfiliado = adminTransaccional.Afiliacion.FirstOrDefault(a => a.IdAfiliciacionCliente == transferencia.IdAfiliacionCliente);

                //    _idAfiliacion = transferencia.IdAfiliacionCliente;
                //    identificacionAfiliado = usuarioAfiliado.IdentificacionCliente;
                //    cuentaAfiliado = usuarioAfiliado.SecuencialCuenta;
                //}
                //else //Propias
                //{
                //    identificacionAfiliado = transferencia.IdentificacionCliente;
                //    _idAfiliacion = 0;
                //    cuentaAfiliado = transferencia.IdAfiliacionCliente;
                //}

                //Transferencia trfC = new Transferencia
                //{
                //    IdAfiliacioncliente = _idAfiliacion, // transferencia.IdAfiliacionCliente,
                //    SecuencialCuentacliente = cuentaAfiliado,
                //    Fecha = DateTime.Now,
                //    SecuencialTransaccion = credito,
                //    Valor = transferencia.Monto,
                //    Descripcion = transferencia.Concepto,
                //    Documento = rdm.Next(6000000, 7000000).ToString() // "Doc"
                //};
                //SaveTransferencia(trfC, identificacionAfiliado);

                //Transferencia trfD = new Transferencia
                //{
                //    IdAfiliacioncliente = _idAfiliacion, // transferencia.IdAfiliacionCliente,
                //    SecuencialCuentacliente = transferencia.SecuencialCuentaCliente,
                //    Fecha = DateTime.Now,
                //    SecuencialTransaccion = debito,
                //    Valor = transferencia.Monto,
                //    Descripcion = transferencia.Concepto,
                //    Documento = rdm.Next(6000000, 7000000).ToString() // "Doc"
                //};
                //SaveTransferencia(trfD, transferencia.IdentificacionCliente);

                #endregion COMMENT

                Random rdm = new Random();
                int credito = 22; //TODO codigo tabla FBS_NEGOCIOSFINANCIEROS.TRANSACCION para nota de creditos
                int debito = 23; //TODO codigo tabla FBS_NEGOCIOSFINANCIEROS.TRANSACCION para nota de debitos

                ExtendModels.Transferencia trfC = new ExtendModels.Transferencia
                {
                    Fecha = DateTime.Now,
                    FechaMaquina = DateTime.Now,
                    CodigousuarioOficina = "ADMIN",
                    Secuencialoficinausuario = 6813,
                    Estaimpreso = false,
                    Numeroverificador = 1,
                    Secuencialtransaccion = debito,
                    Secuencialmoneda = 1,
                    Valor = transferencia.Monto,
                    Secuencialcuenta = transferencia.SecuencialCuentaCliente,
                    Codigoestadocuenta = "A",
                };

                SaveTransferencia(trfC);

                ExtendModels.Transferencia trfD = new ExtendModels.Transferencia
                {
                    Fecha = DateTime.Now,
                    FechaMaquina = DateTime.Now,
                    CodigousuarioOficina = "ADMIN",
                    Secuencialoficinausuario = 6813,
                    Estaimpreso = false,
                    Numeroverificador = 1,
                    Secuencialtransaccion = credito,
                    Secuencialmoneda = 1,
                    Valor = transferencia.Monto,
                    Secuencialcuenta = transferencia.SecuencialCuentaAfiliado,
                    Codigoestadocuenta = "A",
                };

                SaveTransferencia(trfD);
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                result = false;
            }
            return result;
        }

        public int SaveTransferencia(ExtendModels.Transferencia trans)
        {
            Random rdm = new Random();

            #region COMMENT

            //int _id = 0;
            //try
            //{
            //    if (trans != null)
            //    {
            //        string qry = string.Empty;
            //        decimal saldo = 0;
            //        int secuencialMov = 0;

            //        var tieneTransferencias = adminTransaccional.Transferencia.OrderByDescending(r => r.IdTransferencia).FirstOrDefault(a => a.SecuencialCuentacliente == trans.SecuencialCuentacliente);
            //        if (tieneTransferencias != null)
            //        {
            //            saldo = tieneTransferencias.SaldoCuenta;
            //            secuencialMov = tieneTransferencias.SecuencialMovimiento;
            //        }
            //        else
            //        {
            //            qry = "SELECT  top(1) ";
            //            qry += "p.IDENTIFICACION, ";
            //            qry += "MDC.SECUENCIALMOVIMIENTODETALLE, ";
            //            qry += "MDC.SALDOCUENTA ";
            //            qry += "from  FBS_CAPTACIONESVISTA.CUENTAMAESTRO cm ";
            //            qry += "join FBS_CAPTACIONESVISTA.CUENTACLIENTE cc on cm.SECUENCIAL = cc.SECUENCIALCUENTA ";
            //            qry += "join FBS_CLIENTES.CLIENTE C on C.SECUENCIAL = cc.SECUENCIALCLIENTE ";
            //            qry += "JOIN FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL ";
            //            qry += "JOIN FBS_CAPTACIONESVISTA.MOVIMIENTODETALLE_CUENTA MDC ON MDC.SECUENCIALCUENTA = CC.SECUENCIALCUENTA ";
            //            qry += "WHERE p.IDENTIFICACION = '" + identificacion + "' AND cm.SECUENCIAL = '" + trans.SecuencialCuentacliente + "' ";
            //            qry += "group BY p.IDENTIFICACION,MDC.SECUENCIALMOVIMIENTODETALLE,MDC.SALDOCUENTA ";
            //            qry += "order by MDC.SECUENCIALMOVIMIENTODETALLE desc";

            //            using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
            //            {
            //                SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
            //                if (dr.HasRows)
            //                {
            //                    while (dr.Read())
            //                    {
            //                        saldo = dr.GetDecimal(2);
            //                        secuencialMov = dr.GetInt32(1);
            //                    }
            //                }
            //            }
            //        }

            //        trans.SaldoCuenta = (trans.SecuencialTransaccion == 22) ? saldo + trans.Valor : saldo - trans.Valor;
            //        trans.SecuencialMovimiento = secuencialMov + 1;
            //        adminTransaccional.Transferencia.Add(trans);
            //        adminTransaccional.SaveChanges();

            //        _id = trans.IdTransferencia;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _id = 0;
            //}
            //return _id;

            #endregion COMMENT

            int result = 0;

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var secuencialCta = trans.Secuencialcuenta;
                    string documento = rdm.Next(9000000, 10000000).ToString();

                    Movimiento mov = new Movimiento
                    {
                        Documento = documento,
                        Fecha = trans.Fecha,
                        Fechamaquina = trans.FechaMaquina,
                        Codigousuario = trans.CodigousuarioOficina,
                        Secuencialoficinausuario = trans.Secuencialoficinausuario,
                        Estaimpreso = trans.Estaimpreso,
                        Numeroverificador = trans.Numeroverificador
                    };

                    context.Movimiento.Add(mov);
                    context.SaveChanges();

                    if (mov.Secuencial > 0)
                    {
                        Movimientodetalle movdet = new Movimientodetalle
                        {
                            Secuencialmovimiento = mov.Secuencial,
                            Secuencialtransaccion = trans.Secuencialtransaccion,
                            Secuencialmoneda = trans.Secuencialmoneda,
                            Valor = trans.Valor,
                            Secuencialoficinaafectada = trans.Secuencialoficinausuario
                        };
                        context.Movimientodetalle.Add(movdet);
                        context.SaveChanges();

                        if (movdet.Secuencial > 0)
                        {
                            SecuencialMovimientoDetalle = movdet.Secuencial;

                            decimal montoencuenta = 0;
                            var _saldocuenta = context.MovimientodetalleCuenta.OrderByDescending(r => r.Secuencialmovimientodetalle).FirstOrDefault(a => a.Secuencialcuenta == trans.Secuencialcuenta);
                            if (_saldocuenta != null)
                            {
                                switch (trans.Secuencialtransaccion)
                                {
                                    case 22:
                                        montoencuenta = _saldocuenta.Saldocuenta + trans.Valor;
                                        break;

                                    case 23:
                                        montoencuenta = _saldocuenta.Saldocuenta - trans.Valor;
                                        break;

                                    case 35:
                                        montoencuenta = _saldocuenta.Saldocuenta - trans.Valor;
                                        break;

                                    default:
                                        montoencuenta = trans.Valor;
                                        break;
                                }

                                MovimientodetalleCuenta movdetcta = new MovimientodetalleCuenta
                                {
                                    Secuencialmovimientodetalle = movdet.Secuencial,
                                    Secuencialcuenta = secuencialCta,
                                    Saldocuenta = montoencuenta,
                                    Codigoestadocuenta = trans.Codigoestadocuenta
                                };
                                context.MovimientodetalleCuenta.Add(movdetcta);
                                context.SaveChanges();

                                MovimientocuentacompVista movctacomp = new MovimientocuentacompVista
                                {
                                    Secuencialmovimientodetalle = movdet.Secuencial,
                                    Secuencialcuenta = secuencialCta,
                                    Secuencialcomponentevista = 1,
                                    Codigotipomovimiento = "Transferencia",
                                    Valor = trans.Valor,
                                    Saldo = montoencuenta,
                                    Saldocuenta = montoencuenta
                                };
                                context.MovimientocuentacompVista.Add(movctacomp);
                                context.SaveChanges();

                                result = movctacomp.Secuencial;
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    ex.Data.ToString();
                    result = 0;
                    transaction.Rollback();
                    throw;
                }
            }

            return result;
        }

        public List<ClienteCuentaMovimientos> GetMovimientoCuentas(List<ClienteCuentaMovimientos> movimientos, int secuencial) //Movimientos Transferencias AdminTransaccional
        {
            try
            {
                string qry = string.Empty;

                qry = "Select ";
                qry += "tr.IdTransferencia, ";
                qry += "TR.Valor, ";
                qry += "T.NOMBRE, ";
                qry += "TR.Fecha, ";
                qry += "TR.SecuencialCuentaCliente AS SECUENCIAL, ";
                qry += "TR.SecuencialMovimiento AS SECUENCIALMOVIMIENTODETALLE, ";
                qry += "TR.Documento, ";
                qry += "TR.saldocuenta ";
                qry += "FROM [AdminTransaccional].[dbo].[Transferencia] TR join ";
                qry += "FBS_NEGOCIOSFINANCIEROS.TRANSACCION T on tr.secuencialTransaccion = t.SECUENCIAL ";
                qry += "WHERE SecuencialCuentaCliente = '" + secuencial + "'";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            movimientos.Add(new ClienteCuentaMovimientos
                            {
                                CodigoTipocuenta = "",
                                CodigoCuentaMaestro = "",
                                CodigoUsuario = "",
                                NumeroCliente = 0,
                                Identificacion = "",
                                NombreUnido = "",
                                Valor = c.GetDecimal(1),
                                NombreTransacion = c.GetString(2),
                                Fecha = c.GetDateTime(3),
                                SecuencialMovimiento = c.GetInt32(5),
                                SecuencialMovimientoDetalle = c.GetInt32(5),
                                Secuencialtransaccion = 0,
                                Documento = c.GetString(6),
                                SaldoCuenta = c.GetDecimal(7),
                                CodigoEstado = "",
                                NombreEstado = "ACTIVA",
                                NombreTipoCuenta = "",
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
            }
            return movimientos;
        }

        public List<PrestamoMaestros> GetPrestamosByIdentificacionCliente(string identificacion)
        {
            //TODO: Preguntar a Jhonny si esta bien que la busqueda de prestamos esta bien por codigousuario, es decir este pertenece al cliente
            List<PrestamoMaestros> _PrestamosMaestros = new List<PrestamoMaestros>();
            try
            {
                _PrestamosMaestros = (from c in context.Cliente
                                      join pc in context.Prestamocliente on c.Secuencial equals pc.Secuencialcliente
                                      join prema in context.Prestamomaestro on pc.Secuencialprestamo equals prema.Secuencial
                                      join tp in context.TipoPrestamo on prema.Codigotipoprestamo equals tp.Codigo
                                      join ep in context.Estadoprestamo on prema.Codigoestadoprestamo equals ep.Codigo
                                      join pe in context.Persona on c.Secuencialpersona equals pe.Secuencial
                                      where pe.Identificacion == identificacion
                                      select new PrestamoMaestros
                                      {
                                          SECUENCIAL = prema.Secuencial,
                                          NUMEROPRESTAMO = prema.Numeroprestamo,
                                          SECUENCIALEMPRESA = prema.Secuencialempresa,
                                          CODIGOTIPOPRESTAMO = tp.Nombre, //prema.Codigotipoprestamo,
                                          CODIGOPRODUCTOCARTERA = prema.Codigoproductocartera,
                                          SECUENCIALSEGMENTOINTERNO = prema.Secuencialsegmentointerno,
                                          SECUENCIALCONDICIONTABLAAMORTZ = prema.Secuencialcondiciontablaamortz,
                                          CODIGOSUBCALIFICACIONCONTABLE = prema.Codigosubcalificacioncontable,
                                          FRECUENCIAPAGO = prema.Frecuenciapago,
                                          NUMEROCUOTAS = prema.Numerocuotas,
                                          DEUDAINICIAL = prema.Deudainicial,
                                          VALORENTREGADO = prema.Valorentregado,
                                          FECHAADJUDICACION = prema.Fechaadjudicacion,
                                          FECHAVENCIMIENTO = prema.Fechavencimiento,
                                          SECUENCIALMONEDA = prema.Secuencialmoneda,
                                          CODIGOESTADOPRESTAMO = ep.Nombre, // prema.Codigoestadoprestamo,
                                          SALDOACTUAL = prema.Saldoactual,
                                          CALIFICACIONACTUAL = prema.Calificacionactual,
                                          CALIFICACIONPEOR = prema.Calificacionpeor,
                                          CODIGOUSUARIOOFICIAL = prema.Codigousuariooficial,
                                          SECUENCIALOFICINA = prema.Secuencialoficina,
                                          COBRAPORROL = prema.Cobraporrol,
                                          SEREAJUSTA = prema.Sereajusta,
                                          DIASREAJUSTE = prema.Diasreajuste,
                                          FECHACORTE = prema.Fechacorte,
                                          TEACONSEGURO = prema.Teaconseguro,
                                          TEASINSEGURO = prema.Teasinseguro,
                                          ESTAVIGENTECLASIFICACION = prema.Estavigenteclasificacion,
                                          BLOQUEADOTRANSACCIONOPERATIVA = prema.Bloqueadotransaccionoperativa,
                                          NUMEROPAGARE = prema.Numeropagare,
                                          IDENTIFICACIONSUJETOORIGINAL = prema.Identificacionsujetooriginal,
                                          NUMEROVERIFICADOR = prema.Numeroverificador
                                      }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                _PrestamosMaestros = null;
            }
            return _PrestamosMaestros;
        }

        public List<Tipoidentificacion> GetAllTipoIdentificacion()
        {
            List<Tipoidentificacion> list = new List<Tipoidentificacion>();
            try
            {
                list = context.Tipoidentificacion.ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
            }
            return list;
        }

        public CuentasClienteAfiliacion ValidateCuentaTerceros(string cuenta)
        {
            CuentasClienteAfiliacion afiliacion = new CuentasClienteAfiliacion();
            string qry = "";

            try
            {
                qry += "select TOP(1) ";
                qry += "CM.SECUENCIAL, ";
                qry += "CM.CODIGO, ";
                qry += "CM.CODIGOESTADO, ";
                qry += "P.IDENTIFICACION, ";
                qry += "P.SECUENCIALTIPOIDENTIFICACION, ";
                qry += "P.NOMBREUNIDO,";
                qry += "TC.NOMBRE, ";
                qry += "TI.CODIGO, ";
                qry += "p.EMAIL ";
                qry += "FROM   FBS_CAPTACIONESVISTA.CUENTAMAESTRO CM INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.CUENTACLIENTE AS CC ON CM.SECUENCIAL = CC.SECUENCIALCUENTA INNER JOIN ";
                qry += "FBS_CLIENTES.CLIENTE C ON CC.SECUENCIALCLIENTE = C.SECUENCIAL INNER JOIN ";
                qry += "FBS_PERSONAS.PERSONA P ON C.SECUENCIALPERSONA = P.SECUENCIAL INNER JOIN ";
                qry += "FBS_CAPTACIONESVISTA.TIPOCUENTA TC on tC.CODIGO = cm.CODIGOTIPOCUENTA INNER JOIN ";
                qry += "FBS_PERSONAS.TIPOIDENTIFICACION TI on p.SECUENCIALTIPOIDENTIFICACION = TI.SECUENCIAL ";
                qry += "WHERE CM.CODIGOESTADO = 'A' AND CM.CODIGO = '" + cuenta + "'";

                //qry += "WHERE CM.CODIGOESTADO = 'A' AND CM.CODIGO = '" + cuenta + "' AND P.IDENTIFICACION = '" + identificacion + "' AND P.SECUENCIALTIPOIDENTIFICACION = '" + tipoIdentificacion + "'";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            afiliacion.IdAfiliacion = 0;
                            afiliacion.SecuencialCuenta = c.GetInt32(0);
                            afiliacion.TipoDocumento = c.GetString(7);
                            afiliacion.Identificacion = c.GetString(3);
                            afiliacion.TipoCuenta = c.GetString(6);
                            afiliacion.Libreta = c.GetString(1);
                            afiliacion.NombreUnido = c.GetString(5);
                            afiliacion.NombreAfiliado = "";
                            afiliacion.Email = c.GetString(8);
                        }
                    }
                }
            }
            catch (Exception)
            {
                afiliacion = null;
                throw;
            }
            return afiliacion;
        }

        public bool AddDPF(DepositoPlazoFijo plazofijo)
        {
            bool result = true;
            int savedpf = 0;
            try
            {
                ExtendModels.Transferencia trPf = new ExtendModels.Transferencia
                {
                    Fecha = DateTime.Now,
                    FechaMaquina = DateTime.Now,
                    CodigousuarioOficina = "ADMIN",
                    Secuencialoficinausuario = 6813,
                    Estaimpreso = false,
                    Numeroverificador = 1,
                    Secuencialtransaccion = 35,
                    Secuencialmoneda = 1,
                    Valor = plazofijo.Monto,
                    Secuencialcuenta = plazofijo.SecuencialCuenta,
                    Codigoestadocuenta = "A",
                };

                int saveSecuencial = SaveTransferencia(trPf);

                if (saveSecuencial > 0)
                {
                    plazofijo.SecuencialMovimientoDetalle = SecuencialMovimientoDetalle;
                    savedpf = SaveDepositoPlazoFijo(plazofijo);
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                result = false;
                throw;
            }
            return result;
        }

        public int SaveDepositoPlazoFijo(DepositoPlazoFijo dpf)
        {
            int result = 0;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int codigoNumber = 0;
                    var _codigo = context.Depositomaestro.OrderByDescending(r => r.Secuencial).FirstOrDefault().Codigo;

                    int secRangoTemporizacion2 = context.Rangotemporizacion.FirstOrDefault(a => a.Diasinicio <= dpf.Plazoendias && a.Diasfinal >= dpf.Plazoendias).Secuencial; //SOLO PARA PROBAR QUITAR DESPUES

                    if (_codigo != null)
                    {
                        _codigo = _codigo.Replace("-", "");
                        codigoNumber = Convert.ToInt32(_codigo.ToString()) + 1;
                    }
                    Depositomaestro dm = new Depositomaestro
                    {
                        Codigo = codigoNumber.ToString(),
                        Codigotipodeposito = dpf.Codigotipodeposito, //
                        Codigoproductoplazo = dpf.Codigoproductoplazo, //
                        Monto = dpf.Monto,
                        Tasa = dpf.Tasa,
                        Variaciontasa = dpf.Variaciontasa, //
                        Plazoendias = dpf.Plazoendias,
                        Pagoperiodicointeres = dpf.Pagoperiodicointeres,
                        Fechacreacion = dpf.Fechacreacion,
                        Fechavencimiento = dpf.Fechacreacion.AddDays(dpf.Plazoendias),
                        Codigoestadodeposito = dpf.Codigoestadodeposito, //
                        Secuencialmoneda = dpf.Secuencialmoneda, //
                        Secuencialoficina = dpf.Secuencialoficina, //
                        Codigousuario = dpf.Codigousuario, //
                        Fechamaquinacreacion = dpf.Fechamaquinacreacion, //
                        Fechacorte = dpf.Fechacorte, //
                        Numeroverificador = dpf.NumeroverificadorDepositoMaestro, //
                        Secuencialempresa = dpf.Secuencialempresa,
                        Identificacionsujetooriginal = dpf.Identificacionsujetooriginal
                    };

                    context.Depositomaestro.Add(dm);
                    context.SaveChanges();

                    if (dm.Secuencial > 0)
                    {
                        Depositocliente dc = new Depositocliente
                        {
                            Secuencialdeposito = dm.Secuencial,
                            Secuencialcliente = dpf.SecuencialCliente,
                            Esprincipal = dpf.EsPrincipal, //
                            Esconjunto = dpf.EsConjunto, //
                            Estaactivo = dpf.EstaActivo,//
                            Numeroverificador = dpf.NumeroverificadorDepositoCliente, //
                        };
                        context.Depositocliente.Add(dc);
                        context.SaveChanges();

                        if (dc.Secuencial > 0)
                        {
                            DepositocomponentePlazo dcp = new DepositocomponentePlazo
                            {
                                Secuencialdeposito = dm.Secuencial,
                                Secuencialcomponenteplazo = dpf.Secuencialcomponenteplazo,//
                                Codigotipocancelacion = dpf.Codigotipocancelacion, //
                                Saldo = dpf.SaldoDepositoCompPlazo,
                                Numeroverificador = dpf.NumeroverificadorCompPlazo //
                            };
                            context.DepositocomponentePlazo.Add(dcp);
                            context.SaveChanges();

                            if (dcp.Secuencial > 0)
                            {
                                int secRangoTemporizacion = context.Rangotemporizacion.FirstOrDefault(a => a.Diasinicio <= dpf.Plazoendias && a.Diasfinal >= dpf.Plazoendias).Secuencial;

                                DepositocompPlazoRangotempz dcprt = new DepositocompPlazoRangotempz
                                {
                                    Secuencialdepositocomplazo = dcp.Secuencial,
                                    Secuencialrangotemporizacion = secRangoTemporizacion,
                                    Numeroverificador = dpf.NumeroverificadorDepositoCompPlazoRangoTemp
                                };
                                context.DepositocompPlazoRangotempz.Add(dcprt);
                                context.SaveChanges();
                            }
                        }
                    }

                    if (dpf.Beneficiario != null)
                    {
                        var b = dpf.Beneficiario;
                        Depositobeneficiario beneficiario = new Depositobeneficiario
                        {
                            Secuencialdeposito = dm.Secuencial,
                            Beneficiario = b.Beneficiario,
                            Parentesco = b.Parentesco,
                            Direccion = b.Direccion,
                            Telefono = b.Telefono,
                            Numeroverificador = b.Numeroverificador,
                            Esconjunto = b.Esconjunto,
                            Identificacionbeneficiario = b.Identificacionbeneficiario
                        };
                        context.Depositobeneficiario.Add(beneficiario);
                        context.SaveChanges();
                    }

                    MovimientodepositocompPlazo movdepcomppla = new MovimientodepositocompPlazo
                    {
                        Secuencialmovimientodetalle = dpf.SecuencialMovimientoDetalle,
                        Secuencialdeposito = dm.Secuencial,
                        Secuencialcomponenteplazo = dpf.Secuencialcomponenteplazo,
                        Codigotipomovimiento = "Transferencia",
                        Valor = dpf.Monto,
                        Saldo = dpf.Monto
                    };
                    context.MovimientodepositocompPlazo.Add(movdepcomppla);
                    context.SaveChanges();

                    Depositodocumentofisico documento = new Depositodocumentofisico
                    {
                        Secuencialdeposito = dm.Secuencial,
                        Codigousuario = dpf.Codigousuario,
                        Fechasistema = DateTime.Now,
                        Fechamaquina = DateTime.Now,
                        Estaactivo = true,
                        Numeroverificador = 1,
                        Documentofisico = "1"
                    };
                    context.Depositodocumentofisico.Add(documento);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    ex.Data.ToString();
                    transaction.Rollback();
                    result = 0;
                    throw;
                }
            }
            return result;
        }

        public DepositoPlazoFijo GetDpyById(int secuencial)
        {
            DepositoPlazoFijo dpf = new DepositoPlazoFijo();
            try
            {
                var b = context.Depositomaestro.FirstOrDefault(a => a.Secuencial == secuencial);

                if (b != null)
                {
                    dpf.Secuencial = b.Secuencial;
                    dpf.Codigo = b.Codigo;
                    dpf.Codigotipodeposito = b.Codigotipodeposito;
                    dpf.Monto = b.Monto;
                    dpf.Tasa = b.Tasa;
                    dpf.Variaciontasa = b.Variaciontasa;
                    dpf.Plazoendias = b.Plazoendias;
                    dpf.Pagoperiodicointeres = b.Pagoperiodicointeres;
                    dpf.Fechacreacion = b.Fechacreacion;
                    dpf.Codigoestadodeposito = b.Codigoestadodeposito;
                    dpf.Secuencialmoneda = b.Secuencialmoneda;
                    dpf.Secuencialoficina = b.Secuencialoficina;
                    dpf.Codigousuario = b.Codigousuario;
                    dpf.Fechamaquinacreacion = b.Fechamaquinacreacion;
                    dpf.Fechacorte = b.Fechacorte;
                    dpf.NumeroverificadorDepositoMaestro = b.Numeroverificador;
                    dpf.Secuencialempresa = b.Secuencialempresa;
                    dpf.Beneficiario = context.Depositobeneficiario.Where(a => a.Secuencialdeposito == b.Secuencial).Select(c => new Depositobeneficiario
                    {
                        Secuencial = c.Secuencial,
                        Secuencialdeposito = c.Secuencialdeposito,
                        Beneficiario = c.Beneficiario,
                        Parentesco = c.Parentesco,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,
                        Numeroverificador = c.Numeroverificador,
                        Esconjunto = c.Esconjunto,
                        Identificacionbeneficiario = c.Identificacionbeneficiario
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                dpf = null;
            }
            return dpf;
        }

        public List<Depositomaestro> GetMovimientoCuentasDPF(string identificacion)
        {
            List<Depositomaestro> extend = new List<Depositomaestro>();
            //string qry = string.Empty;
            try
            {
                extend = (from dm in context.Depositomaestro
                          join dc in context.Depositocliente on dm.Secuencial equals dc.Secuencialdeposito
                          join c in context.Cliente on dc.Secuencialcliente equals c.Secuencial
                          join p in context.Persona on c.Secuencialpersona equals p.Secuencial
                          where p.Identificacion == identificacion
                          select new Depositomaestro
                          {
                              Secuencial = dm.Secuencial,
                              Codigo = dm.Codigo,
                              Codigotipodeposito = dm.Codigotipodeposito,
                              Codigoproductoplazo = dm.Codigoproductoplazo,
                              Monto = dm.Monto,
                              Tasa = dm.Tasa,
                              Variaciontasa = dm.Variaciontasa,
                              Plazoendias = dm.Plazoendias,
                              Pagoperiodicointeres = dm.Pagoperiodicointeres,
                              Fechacreacion = dm.Fechacreacion,
                              Fechavencimiento = dm.Fechavencimiento,
                              Codigoestadodeposito = dm.Codigoestadodeposito,
                              Secuencialmoneda = dm.Secuencialmoneda,
                              Secuencialoficina = dm.Secuencialoficina,
                              Codigousuario = dm.Codigousuario,
                              Fechamaquinacreacion = dm.Fechamaquinacreacion,
                              Fechacorte = dm.Fechacorte,
                              Numeroverificador = dm.Numeroverificador,
                              Secuencialempresa = dm.Secuencialempresa,
                              Identificacionsujetooriginal = dm.Identificacionsujetooriginal
                          }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                extend = null;
            }
            return extend;
        }
    }
}