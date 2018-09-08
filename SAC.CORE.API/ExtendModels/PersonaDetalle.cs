using System.Collections.Generic;

namespace SAC.CORE.API.ExtendModels
{
    public class PersonaDetalle
    {
        public AdminUsuario _AdminUsuario { get; set; }
        public Personas _Persona { get; set; }
        public PersonaNatural _PersonaNatural { get; set; }
        public List<TelefonoPersonas> _TelefonoPersonas { get; set; }
    }
}