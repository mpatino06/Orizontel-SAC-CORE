namespace SAC.CORE.API.ModelAdmin
{
    public partial class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoServicio { get; set; }
        public bool Activo { get; set; }
    }
}