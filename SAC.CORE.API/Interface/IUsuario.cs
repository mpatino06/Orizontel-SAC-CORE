using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using SAC.CORE.API.Models;
using System.Collections.Generic;

namespace SAC.CORE.API.Interface
{
    public interface IUsuario
    {
        UsuarioComplementoExtend GetUserByCode(string code);

        PersonaDetalle GetUserByIdentificacion(string identificacion);

        bool Update(AdminUsuario adminUsuario);

        AdminUsuario GetUserByNameAndIdentificacion(string user);

        List<Preguntaseguridad> GetAllPreguntas();
    }
}