using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using System;
using System.Collections.Generic;

namespace SAC.CORE.API.Interface
{
    public interface IAdminUsuario
    {
        AdminUsuario GetUsuario(string user, string pass, bool guardaMovimiento);

        AdminUsuario SaveUsuario(AdminUsuario usuario);

        AdminUsuario ValidateUser(string codigo, string identificacion, DateTime fecha);

        bool SavePreguntaUsuario(List<Usuariopregunta> preguntas);
    }
}