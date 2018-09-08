using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Interface;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAC.CORE.API.Services
{
    public class AdminUsuarioRepository : IAdminUsuario
    {
        private AdminTransaccionalContext admincontext;
        private FBS_SacAmbatoContext context;

        public AdminUsuarioRepository()
        {
            admincontext = new AdminTransaccionalContext();
            context = new FBS_SacAmbatoContext();
        }

        public AdminUsuario GetUsuario(string user, string pass, bool guardaMovimiento)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            try
            {
                var result = admincontext.Usuario.FirstOrDefault(a => a.Codigo == user && a.Clave == pass);
                if (result != null)
                {
                    adminUsuario.Id = result.Id;
                    adminUsuario.Identificacion = result.Identificacion;
                    adminUsuario.Codigo = result.Codigo;
                    adminUsuario.Clave = result.Clave;
                    adminUsuario.FechaRegistro = result.FechaRegistro;
                    adminUsuario.Activo = result.Activo;
                    adminUsuario.Imagen = result.Imagen;
                    adminUsuario.RutaImagen = admincontext.Usuarioimagen.FirstOrDefault(a => a.CodigoImagen == result.Imagen).Ruta;
                    adminUsuario.UltimoIgreso = admincontext.Usuariomovimiento.LastOrDefault(a => a.IdUsuario == result.Id).Fecha;
                }

                if (guardaMovimiento)
                {
                    var usuario = new UsuarioMovimiento
                    {
                        IdUsuario = Convert.ToInt32(adminUsuario.Id),
                        Fecha = DateTime.Now
                    };
                    SaveMovimiento(usuario);
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                adminUsuario = null;
            }
            return adminUsuario;
        }

        public AdminUsuario SaveUsuario(AdminUsuario usuario)
        {
           

            using (var transaction = admincontext.Database.BeginTransaction())
            {
                #region MyRegion
                try
                {
                    if (usuario.Identificacion != null)
                    {
                        if (context.Persona.Any(a => a.Identificacion == usuario.Identificacion))
                        {
                            ModelAdmin.Usuario _user = new ModelAdmin.Usuario
                            {
                                Identificacion = usuario.Identificacion,
                                Codigo = usuario.Codigo,
                                Clave = usuario.Clave,
                                FechaRegistro = DateTime.Now,
                                Activo = true,
                                Imagen = usuario.Imagen,
                                TextoImagen = usuario.TextoImagen
                            };

                            admincontext.Usuario.Add(_user);
                            admincontext.SaveChanges();
                            usuario.Id = _user.Id;

                            if (usuario.Id > 0)
                            {
                                usuario.RutaImagen = admincontext.Usuarioimagen.FirstOrDefault(a => a.CodigoImagen == _user.Imagen).Ruta;
                                usuario.FechaRegistro = DateTime.Now;

                                var _usuario = new UsuarioMovimiento
                                {
                                    IdUsuario = Convert.ToInt32(usuario.Id),
                                    Fecha = DateTime.Now
                                };

                                SaveMovimiento(_usuario);

                                var preguntas = usuario.preguntas.Select(a => new Usuariopregunta { Idusuario = _user.Id, Idpregunta = a.Idpregunta, Respuesta = a.Respuesta }).ToList();


                                admincontext.Usuariopregunta.AddRange(preguntas);
                                admincontext.SaveChanges();

                                transaction.Commit();
                                //SavePreguntaUsuario(preguntas);
                            }
                        }
                        else
                            usuario.Message = "Identificacion NO registrada";
                    }

                }
                catch (Exception ex)
                {
                    usuario.Message = ex.Message.ToString();
                    transaction.Rollback();
                }
                #endregion


            }
            return usuario;
        }

        public AdminUsuario ValidateUser(string codigo, string identificacion, DateTime fecha)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            try
            {
                adminUsuario = (from p in context.Persona
                                join pn in context.Personanatural on p.Secuencial equals pn.Secuencialpersona
                                where p.Identificacion == identificacion && pn.FechaNacimiento == fecha
                                select new AdminUsuario
                                {
                                    Identificacion = p.Identificacion,
                                    NombreCompleto = p.Nombreunido,
                                    Email = p.Email
                                }).FirstOrDefault();

                adminUsuario.CodigoPermitido = !admincontext.Usuario.Any(a => a.Codigo == codigo);
            }
            catch (Exception ex)
            {
                adminUsuario.Message = ex.Message.ToString();
            }
            return adminUsuario;
        }

        public UsuarioMovimiento SaveMovimiento(UsuarioMovimiento usuario)
        {
            try
            {
                if (usuario != null)
                {
                    admincontext.Usuariomovimiento.Add(usuario);
                    admincontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Data.ToString();
                usuario = null;
            }
            return usuario;
        }

        public bool SavePreguntaUsuario(List<Usuariopregunta> preguntas)
        {
            bool result = false;
            using (var transaction = admincontext.Database.BeginTransaction())
            {
                try
                {
                    admincontext.Usuariopregunta.AddRange(preguntas);
                    admincontext.SaveChanges();

                    transaction.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ex.Data.ToString();
                }
            }
            return result;
        }
    }
}