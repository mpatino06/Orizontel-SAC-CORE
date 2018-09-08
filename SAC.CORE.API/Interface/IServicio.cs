using SAC.CORE.API.ExtendModels;
using SAC.CORE.API.ModelAdmin;
using System.Collections.Generic;

namespace SAC.CORE.API.Interface
{
    internal interface IServicio
    {
        List<Tiposervicio> GetServicios();

        List<Servicio> GetServicioByIdTipoServicio(int Id);

        int SaveAfiliacionCliente(Afiliacion afiliacion);

        List<AfiliacionServicios> GetAllAfiliacion(string identificacion);

        AfiliacionServicios GetAfiliacionById(int IdAfiliacion);

        bool UpdateAfiliacion(AfiliacionServicios afiliacion);

        bool DeleteAfiliacion(int Idafiliacion);

        List<PlazoFijoPeriodo> GetPlazoPeriodo();

        PlazoFijoTasas GetPlazoFijoTazas(int plazo, decimal monto);
    }
}