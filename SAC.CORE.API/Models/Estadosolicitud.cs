﻿namespace SAC.CORE.API.Models
{
    public partial class Estadosolicitud
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Secuencialempresa { get; set; }
        public bool Estaactivo { get; set; }
        public int Numeroverificador { get; set; }
    }
}