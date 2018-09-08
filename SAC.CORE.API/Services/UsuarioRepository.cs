using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using SAC.CORE.API.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SAC.CORE.API.Services
{
    public class UsuarioRepository : IUsuario
    {
        private AdminTransaccionalContext admincontext;
        private FBS_SacAmbatoContext context;

        public UsuarioRepository()
        {
            admincontext = new AdminTransaccionalContext();
            context = new FBS_SacAmbatoContext();
        }

        public UsuarioComplementoExtend GetUserByCode(string code)
        {
            UsuarioComplementoExtend extend = new UsuarioComplementoExtend();
            //await Task.Run(() =>
            // {
            string qry = null;
            try
            {
                #region QUERY SQL

                qry = "SELECT";
                qry += " US.CODIGO,";
                qry += " US.NOMBRE,";
                qry += " US.SECUENCIALOFICINA,";
                qry += " US.ESTAACTIVO,";
                qry += " US.NUMEROVERIFICADOR,";
                qry += " USC.CODIGOUSUARIO,";
                qry += " USC.SECUENCIALPERSONA,";
                qry += " USC.FECHACREACION,";
                qry += " (UPPER(sys.fn_varbintohexsubstring(0, HASHBYTES('SHA1', CAST(USC.CLAVE + '123456' as VARCHAR)), 1, 0))) AS _CLAVE,";
                qry += " USC.EMAILINTERNO,";
                qry += " USC.FECHAULTIMOCAMBIOCLAVE,";
                qry += " USC.CAMBIOCLAVEPROXIMOINGRESO,";
                qry += " USC.PERIODICIDADCAMBIOCLAVE,";
                qry += " USC.ESINTERNO,";
                qry += " USC.NUMEROVERIFICADOR AS NUMEROVERICADORUSUARIOCOMPLEMENTO,";
                qry += " USC.PUEDECONSULTAROTROSUSUARIOS";
                qry += " FROM FBS_SEGURIDADES.USUARIO US";
                qry += " INNER JOIN FBS_SEGURIDADES.USUARIO_COMPLEMENTO USC ON US.CODIGO = USC.CODIGOUSUARIO";
                qry += " WHERE US.CODIGO = '" + code + "'";

                #endregion QUERY SQL

                using (SqlConnection conn = new SqlConnection(SQLHelper.ConnectionString))
                {
                    SqlDataReader dr = SQLHelper.ExecuteReader(conn, System.Data.CommandType.Text, qry, null);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            extend.Codigousuario = dr.GetString(0);
                            extend.Nombre = dr.GetString(1);
                            extend.Secuencialoficina = dr.GetInt32(2);
                            extend.Estaactivo = dr.GetBoolean(3);
                            extend.NumeroverificadorUsuario = dr.GetInt32(4);
                            extend.Codigousuario = dr.GetString(5);
                            extend.Secuencialpersona = dr.GetInt32(6);
                            extend.Fechacreacion = dr.GetDateTime(7);
                            extend.Clave = dr.GetString(8);
                            extend.Emailinterno = dr.GetString(9);
                            extend.Fechaultimocambioclave = dr.GetDateTime(10);
                            extend.Cambioclaveproximoingreso = dr.GetBoolean(11);
                            extend.Periodicidadcambioclave = dr.GetInt32(12);
                            extend.Esinterno = dr.GetBoolean(13);
                            extend.NumeroverificadorUsuarioComplemento = dr.GetInt32(14);
                            extend.Puedeconsultarotrosusuarios = dr.GetBoolean(15);
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
                //extend.Emailinterno = "Error " + ex.Message.ToString();
            }

            return extend;
        }

        public PersonaDetalle GetUserByIdentificacion(string identificacion)
        {
            var _AdminUsuario1 = admincontext.Usuario.Where(a => a.Identificacion == identificacion).Select(b => new AdminUsuario
            {
                Id = b.Id,
                Identificacion = b.Identificacion,
                Codigo = b.Codigo,
                Clave = b.Clave,
                FechaRegistro = b.FechaRegistro,
                Activo = b.Activo,
                Imagen = b.Imagen,
                TextoImagen = b.TextoImagen
            }).FirstOrDefault();

            var _rutaImagen = admincontext.Usuarioimagen.FirstOrDefault(a => a.CodigoImagen == _AdminUsuario1.Imagen).Ruta;
            var _ultimoIgreso = admincontext.Usuariomovimiento.LastOrDefault(a => a.IdUsuario == _AdminUsuario1.Id).Fecha;

            _AdminUsuario1.RutaImagen = _rutaImagen;
            _AdminUsuario1.UltimoIgreso = _ultimoIgreso;

            PersonaDetalle persona = new PersonaDetalle();
            try
            {
                persona = (from p in context.Persona
                           join pn in context.Personanatural on p.Secuencial equals pn.Secuencialpersona
                           join ec in context.Estadocivil on pn.Codigoestadocivil equals ec.Codigo
                           join te in context.Tipoeducacion on pn.Codigotipoeducacion equals te.Codigo
                           join tv in context.Tipovivienda on pn.Codigotipovivienda equals tv.Codigo
                           join pro in context.Profesion on pn.Codigoprofesion equals pro.Codigo
                           where p.Identificacion == identificacion
                           select new PersonaDetalle
                           {
                               //_AdminUsuario = admincontext.Usuario.Where(a => a.Identificacion == identificacion).Select(b => new AdminUsuario
                               //{
                               //    Id = b.Id,
                               //    Identificacion = b.Identificacion,
                               //    Codigo = b.Codigo,
                               //    Clave = b.Clave,
                               //    FechaRegistro = b.FechaRegistro,
                               //    Activo = b.Activo,
                               //    Imagen = b.Imagen,
                               //    RutaImagen = admincontext.Usuarioimagen.FirstOrDefault(a => a.CodigoImagen == b.Imagen).Ruta,
                               //    UltimoIgreso = admincontext.Usuariomovimiento.LastOrDefault(a => a.IdUsuario == b.Id).Fecha
                               //}).FirstOrDefault(),
                               _Persona = new Personas
                               {
                                   SECUENCIAL = p.Secuencial,
                                   IDENTIFICACION = p.Identificacion,
                                   NOMBREUNIDO = p.Nombreunido,
                                   DIRECCIONDOMICILIO = p.Direcciondomicilio,
                                   REFERENCIADOMICILIARIA = p.Referenciadomiciliaria,
                                   EMAIL = p.Email,
                                   SECUENCIALTIPOIDENTIFICACION = p.Secuencialtipoidentificacion,
                                   SECUENCIALDIVPOLRESIDENCIA = p.Secuencialdivpolresidencia,
                                   CODIGOPAISORIGEN = p.Codigopaisorigen,
                                   NUMEROVERIFICADOR = p.Numeroverificador,
                                   SECUENCIALDIVACTIVIDADECON = p.Secuencialdivactividadecon,
                                   CODIGOSOCIOMIGRA = p.Codigosociomigra,
                                   IDENTIFICACIONMIGRA = p.Identificacionmigra
                               },
                               _PersonaNatural = new PersonaNatural
                               {
                                   Secuencialpersona = pn.Secuencialpersona,
                                   Apellidos = pn.Apellidos,
                                   Nombres = pn.Nombres,
                                   FechaNacimiento = pn.FechaNacimiento,
                                   Esmasculino = pn.Esmasculino,
                                   Estadocivil = ec.Nombre,
                                   Tipoeducacion = te.Nombre,
                                   Tipovivienda = tv.Nombre,
                                   Profesion = pro.Nombre,
                                   Egresosmensuales = pn.Egresosmensuales,
                                   Patrimonio = pn.Patrimonio,
                                   ApellidoPaterno = pn.ApellidoPaterno,
                                   ApellidoMaterno = pn.ApellidoMaterno,
                                   Primernombre = pn.Primernombre,
                                   Segundonombre = pn.Segundonombre,
                                   Lugarnacimiento = pn.Lugarnacimiento,
                                   Activostotales = pn.Activostotales,
                                   Pasivostotales = pn.Pasivostotales,
                                   Cargasfamiliares = pn.Cargasfamiliares
                               },
                               _TelefonoPersonas = context.Telefonopersona.Where(a => a.Secuencialpersona == p.Secuencial).Select(a => new TelefonoPersonas
                               {
                                   SECUENCIAL = a.Secuencial,
                                   SECUENCIALPERSONA = a.Secuencialpersona,
                                   CODIGOEMPRESATELEFONICA = a.Codigoempresatelefonica,
                                   CODIGOTIPOTELEFONO = a.Codigotipotelefono,
                                   NUMEROTELEFONO = a.Numerotelefono,
                                   DESCRIPCION = a.Descripcion,
                                   ESTAACTIVO = a.Estaactivo,
                                   NUMEROVERIFICADOR = a.Numeroverificador
                               }).ToList()
                           }).FirstOrDefault();

                persona._AdminUsuario = _AdminUsuario1;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                persona = null;
            }
            return persona;
        }

        public bool Update(AdminUsuario adminUsuario)
        {
            bool result = false;
            try
            {
                ModelAdmin.Usuario _usuario = admincontext.Usuario.FirstOrDefault(a => a.Identificacion == adminUsuario.Identificacion || a.Codigo == adminUsuario.Identificacion);

                _usuario.Imagen = adminUsuario.Imagen;
                _usuario.TextoImagen = adminUsuario.TextoImagen;
                _usuario.Clave = adminUsuario.Clave;

                if (_usuario != null)
                {
                    admincontext.Usuario.Attach(_usuario);
                    admincontext.SaveChanges();
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

        public AdminUsuario GetUserByNameAndIdentificacion(string user)
        {
            var item = new AdminUsuario();
            try
            {
                item = admincontext.Usuario.Where(a => a.Identificacion == user || a.Codigo == user).Select(b => new AdminUsuario
                {
                    Id = b.Id,
                    Identificacion = b.Identificacion,
                    Codigo = b.Codigo,
                    Clave = b.Clave,
                    FechaRegistro = b.FechaRegistro,
                    Activo = b.Activo,
                    Imagen = b.Imagen,
                    TextoImagen = b.TextoImagen,
                }).FirstOrDefault();

                var persona = context.Persona.FirstOrDefault(a => a.Identificacion == item.Identificacion);
                item.NombreCompleto = persona.Nombreunido;
                item.Email = persona.Email;
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return item;
        }

        public List<Preguntaseguridad> GetAllPreguntas()
        {
            var list = new List<Preguntaseguridad>();
            try
            {
                list = admincontext.Preguntaseguridad.ToList();
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                throw;
            }
            return list;
        }
    }
}