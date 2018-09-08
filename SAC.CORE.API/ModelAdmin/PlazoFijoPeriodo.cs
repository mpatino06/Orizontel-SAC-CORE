namespace SAC.CORE.API.ModelAdmin
{
    public partial class PlazoFijoPeriodo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MinimoDias { get; set; }
        public int MaximoDias { get; set; }
        public bool Activo { get; set; }
    }
}