namespace SAC.CORE.API.ExtendModels
{
    public class PlazoFijoTasas
    {
        public int Id { get; set; }
        public int IdPlazoFijo { get; set; }
        public string PlazoFijo { get; set; }
        public int IdPlazoPeriodo { get; set; }
        public string PlazoPeriodo { get; set; }
        public decimal MontoMinimo { get; set; }
        public decimal MontoMaximo { get; set; }
        public int MinimoDias { get; set; }
        public int MaximoDias { get; set; }
        public decimal Nominal { get; set; }
        public decimal Efectiva { get; set; }
        public bool Activa { get; set; }
        public string MontoLetras { get; set; }
    }
}