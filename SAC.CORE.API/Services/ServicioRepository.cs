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
    public class ServicioRepository : IServicio
    {
        private readonly FBS_SacAmbatoContext context;
        private AdminTransaccionalContext adminTransaccional;

        public ServicioRepository()
        {
            context = new FBS_SacAmbatoContext();
            adminTransaccional = new AdminTransaccionalContext();
        }

        public List<Tiposervicio> GetServicios()
        {
            List<Tiposervicio> list = new List<Tiposervicio>();
            try
            {
                list = adminTransaccional.Tiposervicio.ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
                throw;
            }
            return list;
        }

        public List<Servicio> GetServicioByIdTipoServicio(int Id)
        {
            List<Servicio> list = new List<Servicio>();
            try
            {
                list = adminTransaccional.Servicio.Where(a => a.IdTipoServicio == Id).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
                throw;
            }
            return list;
        }

        public int SaveAfiliacionCliente(Afiliacion afiliacion)
        {
            int _save = 0;
            try
            {
                adminTransaccional.Afiliacion.Add(afiliacion);
                adminTransaccional.SaveChanges();

                _save = afiliacion.IdAfiliciacionCliente;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                _save = 0;
                throw;
            }
            return _save;
        }

        public List<AfiliacionServicios> GetAllAfiliacion(string identificacion)
        {
            List<AfiliacionServicios> list = new List<AfiliacionServicios>();
            try
            {
                string qry = "";

                qry += "SELECT  t.IdAfiliciacionCliente ";
                qry += ",t.IdentificacionUsuario ";
                qry += ",t.IdentificacionCliente ";
                qry += ",t.IdServicio ";
                qry += ",t.Nombrebeneficiario ";
                qry += ",t.SecuencialCuenta ";
                qry += ",t.NombreAfiliacion ";
                qry += ",t.NumeroCuenta ";
                qry += ",t.CodigoBanco ";
                qry += ",t.Email ";
                qry += ",t.Fecha ";
                qry += ",t.MontoMaximo ";
                qry += ",t.EstaActivo ";
                qry += ",s.Nombre ";
                qry += ",cm.CODIGO ";
                qry += "FROM AdminTransaccional.dbo.Afiliacion t INNER JOIN ";
                qry += "[AdminTransaccional].dbo.servicio s on t.IdServicio = s.Id INNER JOIN ";
                qry += "{NOMBRE_BD}.FBS_CAPTACIONESVISTA.CUENTAMAESTRO CM on t.SecuencialCuenta = cm.SECUENCIAL ";
                qry += " where t.IdentificacionUsuario = '" + identificacion + "' AND t.EstaActivo = '1'";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry.Replace("{NOMBRE_BD}", conn.Database.ToString()), null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            list.Add(new AfiliacionServicios
                            {
                                IdAfiliciacionCliente = c.GetInt32(0),
                                IdentificacionUsuario = c.GetString(1),
                                IdentificacionCliente = c.GetString(2),
                                IdServicio = c.GetInt32(3),
                                NombreServicio = c.GetString(13),
                                NombreBeneficiario = c.GetString(4),
                                SecuencialCuenta = c.GetInt32(5),
                                NumeroCuenta = c.GetString(14),
                                NombreAfiliacion = c.GetString(6),
                                CodigoBanco = "", // c.GetString(7),
                                Email = "", // c.GetString(8),
                                Fecha = c.GetDateTime(10),
                                MontoMaximo = c.GetDecimal(11)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
                throw;
            }
            return list;
        }

        public AfiliacionServicios GetAfiliacionById(int IdAfiliacion)
        {
            List<AfiliacionServicios> list = new List<AfiliacionServicios>();
            try
            {
                string qry = "";

                qry += "SELECT  t.IdAfiliciacionCliente ";
                qry += ",t.IdentificacionUsuario ";
                qry += ",t.IdentificacionCliente ";
                qry += ",t.IdServicio ";
                qry += ",t.Nombrebeneficiario ";
                qry += ",t.SecuencialCuenta ";
                qry += ",t.NombreAfiliacion ";
                qry += ",t.NumeroCuenta ";
                qry += ",t.CodigoBanco ";
                qry += ",t.Email ";
                qry += ",t.Fecha ";
                qry += ",t.MontoMaximo ";
                qry += ",t.EstaActivo ";
                qry += ",s.Nombre ";
                qry += ",cm.CODIGO ";
                qry += "FROM AdminTransaccional.dbo.Afiliacion t INNER JOIN ";
                qry += "[AdminTransaccional].dbo.servicio s on t.IdServicio = s.Id INNER JOIN ";
                qry += "{NOMBRE_BD}.FBS_CAPTACIONESVISTA.CUENTAMAESTRO CM on t.SecuencialCuenta = cm.SECUENCIAL ";
                qry += " where t.IdAfiliciacionCliente = '" + IdAfiliacion + "' AND t.EstaActivo = '1'";

                //string? _codigoBanco = "";
                //string _email = "";
                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry.Replace("{NOMBRE_BD}", conn.Database.ToString()), null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            list.Add(new AfiliacionServicios
                            {
                                IdAfiliciacionCliente = c.GetInt32(0),
                                IdentificacionUsuario = c.GetString(1),
                                IdentificacionCliente = c.GetString(2),
                                IdServicio = c.GetInt32(3),
                                NombreServicio = c.GetString(13),
                                NombreBeneficiario = c.GetString(4),
                                SecuencialCuenta = c.GetInt32(5),
                                NumeroCuenta = c.GetString(14),
                                NombreAfiliacion = c.GetString(6),
                                CodigoBanco = c.IsDBNull(8) ? "" : c.GetString(8),
                                Email = c.IsDBNull(9) ? "" : c.GetString(9),
                                Fecha = c.GetDateTime(10),
                                MontoMaximo = c.GetDecimal(11)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
                throw;
            }
            return list.FirstOrDefault();
        }

        public bool UpdateAfiliacion(AfiliacionServicios afiliacion)
        {
            bool result = false;
            try
            {
                Afiliacion afiliacionUpdate = adminTransaccional.Afiliacion.FirstOrDefault(a => a.IdAfiliciacionCliente == afiliacion.IdAfiliciacionCliente);

                afiliacionUpdate.NombreAfiliacion = afiliacion.NombreAfiliacion;
                afiliacionUpdate.Email = afiliacion.Email;
                afiliacionUpdate.MontoMaximo = afiliacion.MontoMaximo;

                if (afiliacionUpdate != null)
                {
                    adminTransaccional.Afiliacion.Attach(afiliacionUpdate);
                    adminTransaccional.SaveChanges();
                }

                result = true;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                result = false;
            }
            return result;
        }

        public bool DeleteAfiliacion(int Idafiliacion) //Change estatus
        {
            bool result = false;
            try
            {
                //Afiliacion afiliacionDelete = adminTransaccional.Afiliacion.FirstOrDefault(a => a.IdAfiliciacionCliente == Idafiliacion);

                //if (afiliacionDelete != null)
                //{
                //    adminTransaccional.Afiliacion.Remove(afiliacionDelete);
                //    adminTransaccional.SaveChanges();
                //}

                Afiliacion afiliacionUpdate = adminTransaccional.Afiliacion.FirstOrDefault(a => a.IdAfiliciacionCliente == Idafiliacion);

                afiliacionUpdate.EstaActivo = false;

                if (afiliacionUpdate != null)
                {
                    adminTransaccional.Afiliacion.Attach(afiliacionUpdate);
                    adminTransaccional.SaveChanges();
                }

                result = true;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                result = false;
            }
            return result;
        }

        public List<PlazoFijoPeriodo> GetPlazoPeriodo()
        {
            List<PlazoFijoPeriodo> list = new List<PlazoFijoPeriodo>();
            try
            {
                list = adminTransaccional.PlazoFijoPeriodo.ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                list = null;
                throw;
            }
            return list;
        }

        public PlazoFijoTasas GetPlazoFijoTazas(int plazo, decimal monto)
        {
            PlazoFijoTasas pf = new PlazoFijoTasas();
            string qry = "";
            try
            {
                qry = "SELECT TOP(1) Pfti.Id, ";
                qry += "Pfti.IdPlazoFijo, ";
                qry += "Pfti.IdPlazoPeriodo, ";
                qry += "Pfp.Nombre AS NombrePlazoFijoTasaInteres, ";
                qry += "Pf.Nombre AS NombrePlazoFijo, ";
                qry += "Pf.MontoMinimo, ";
                qry += "Pf.MontoMaximo, ";
                qry += "Pfp.MinimoDias, ";
                qry += "Pfp.MaximoDias, ";
                qry += "Pfti.Nominal, ";
                qry += "Pfti.Efectiva, ";
                qry += "Pfti.Ativo ";
                qry += "FROM   PlazoFijo AS Pf INNER JOIN ";
                qry += "PlazoFijoTasaInteres AS Pfti ON Pf.Id = Pfti.IdPlazoFijo INNER JOIN ";
                qry += "PlazoFijoPeriodo AS Pfp ON Pfti.IdPlazoPeriodo = Pfp.Id ";
                qry += "WHERE (Pfp.MinimoDias <='" + plazo + "') AND (Pfp.MaximoDias >='" + plazo + "') AND (Pf.MontoMinimo <='" + monto + "') AND(Pf.MontoMaximo >= '" + monto + "')";

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionStringAdmin))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            pf.Id = c.GetInt32(0);
                            pf.IdPlazoFijo = c.GetInt32(1);
                            pf.IdPlazoPeriodo = c.GetInt32(2);
                            pf.PlazoPeriodo = c.GetString(3);
                            pf.PlazoFijo = c.GetString(4);
                            pf.MontoMinimo = c.GetDecimal(5);
                            pf.MontoMaximo = c.GetDecimal(6);
                            pf.MinimoDias = c.GetInt32(7);
                            pf.MaximoDias = c.GetInt32(8);
                            pf.Nominal = c.GetDecimal(9);
                            pf.Efectiva = c.GetDecimal(10);
                            pf.Activa = c.GetBoolean(11);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                pf = null;
                throw;
            }
            return pf;
        }
    }
}