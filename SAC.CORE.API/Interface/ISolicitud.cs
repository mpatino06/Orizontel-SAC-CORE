using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.Models;
using System.Collections.Generic;

namespace SAC.CORE.API.Interface
{
    internal interface ISolicitud
    {
        GetInfoSolicitudPrestamo GetInfosolicitudPrestamo();

        SolicitudPrestamo SaveSolicitud(SolicitudPrestamo solicitud);

        TipoPrestamo GetByNombre(string nombre);

        List<SolicitudPrestamo> GetSolicitudByID(string identificacion);
    }
}