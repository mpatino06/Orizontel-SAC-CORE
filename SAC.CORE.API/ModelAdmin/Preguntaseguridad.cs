namespace SAC.CORE.API.ModelAdmin
{
    public partial class Preguntaseguridad
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public int Idtiporespuesta { get; set; }
        public bool Activo { get; set; }
    }
}