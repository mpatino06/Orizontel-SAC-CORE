using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAC.CORE.API.Services
{
    public class SolicitudRepository : ISolicitud
    {
        private FBS_SacAmbatoContext contex;

        public SolicitudRepository()
        {
            contex = new FBS_SacAmbatoContext();
        }

        public GetInfoSolicitudPrestamo GetInfosolicitudPrestamo()
        {
            GetInfoSolicitudPrestamo info = new GetInfoSolicitudPrestamo();
            try
            {
                info.prestamos = contex.TipoPrestamo.ToList();
                info.amortizacion = contex.Condiciontablaamortizacion.ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return info;
        }

        public SolicitudPrestamo SaveSolicitud(SolicitudPrestamo solicitud)
        {
            try
            {
                int ultimaSolicitud = contex.Solicitudmaestro.OrderByDescending(a => a.Secuencial).Select(a => a.Numerosolicitud).First();

                Solicitudmaestro _solicitud = new Solicitudmaestro
                {
                    Secuencial = solicitud.Secuencial,
                    Numerosolicitud = ultimaSolicitud + 1,
                    Montosolicitado = solicitud.MontoSolicitado,
                    Montoaprobado = 0,
                    Fechaingreso = DateTime.Now,
                    Codigoestadosolicitud = "IN",
                    Codigousuarioingreso = "ADMIN",
                    Secuencialoficina = 6813,
                    Esrenovacion = false,
                    Numeroverificador = 1,
                    Numeroprestamomigra = "1",
                    Numerosociomigra = solicitud.NumerosocioMigra,
                };

                contex.Solicitudmaestro.Add(_solicitud);
                contex.SaveChanges();

                if (_solicitud.Secuencial > 0)
                {
                    SolicitudmaestroPrestamo _solprestamo = new SolicitudmaestroPrestamo
                    {
                        Secuencialsolicitud = _solicitud.Secuencial,
                        Codigotipoprestamo = solicitud.CodigoTipoPrestamo,
                        Codigoproductocartera = solicitud.CodigoProductoCartera,
                        Secuencialsegmentointerno = solicitud.SecuencialSegmentoInterno,
                        Secuencialcondiciontablaamortz = solicitud.SecuencialCondiccionTablaAmortz,
                        Codigosubcalificacioncontable = solicitud.CodigoSubcalificacionContable,
                        Frecuenciapago = 30, // solicitud.FrecuenciaPago,
                        Numerocuotas = solicitud.NumeroCuotas,
                        Cobraporrol = solicitud.CobraporRol,
                        Codigoorigenrecurso = solicitud.CodigoOrigenRecurso
                    };
                    var result = SaveSolictudMaestroPrestamo(_solprestamo);
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return solicitud;
        }

        public SolicitudmaestroPrestamo SaveSolictudMaestroPrestamo(SolicitudmaestroPrestamo solicitud)
        {
            try
            {
                contex.SolicitudmaestroPrestamo.Add(solicitud);
                contex.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return solicitud;
        }

        public TipoPrestamo GetByNombre(string nombre)
        {
            var item = new TipoPrestamo();
            try
            {
                item = contex.TipoPrestamo.FirstOrDefault(a => a.Nombre == nombre);
            }
            catch (Exception)
            {
                item = null;
                throw;
            }
            return item;
        }

        public List<SolicitudPrestamo> GetSolicitudByID(string identificacion)
        {
            List<SolicitudPrestamo> solicitud = new List<SolicitudPrestamo>();
            try
            {
                solicitud = (from sm in contex.Solicitudmaestro
                             join sm_p in contex.SolicitudmaestroPrestamo on sm.Secuencial equals sm_p.Secuencialsolicitud
                             join tp in contex.TipoPrestamo on sm_p.Codigotipoprestamo equals tp.Codigo
                             join es in contex.Estadosolicitud on sm.Codigoestadosolicitud equals es.Codigo
                             join cta in contex.Condiciontablaamortizacion on sm_p.Secuencialcondiciontablaamortz equals cta.Secuencial
                             where sm.Numerosociomigra == identificacion
                             select new SolicitudPrestamo
                             {
                                 Secuencial = sm.Secuencial,
                                 NumeroSolicitud = sm.Numerosolicitud,
                                 MontoSolicitado = sm.Montosolicitado,
                                 MontoAprobado = sm.Montoaprobado,
                                 FechaIngreso = sm.Fechaingreso,
                                 EstadoSolicitud = es.Nombre,
                                 TipoPrestamo = tp.Nombre,
                                 NumeroCuotas = sm_p.Numerocuotas,
                                 CondiccionTablaAmortz = cta.Nombre
                             }).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return solicitud;
        }
    }
}