namespace SAC.CORE.API.Models
{
    public partial class Persona
    {
        public Persona()
        {
            //Telefonopersona = new HashSet<Telefonopersona>();
            //UsuarioComplemento = new HashSet<UsuarioComplemento>();
            //UsuarioComplemento1 = new HashSet<UsuarioComplemento1>();
        }

        public int Secuencial { get; set; }
        public string Identificacion { get; set; }
        public string Nombreunido { get; set; }
        public string Direcciondomicilio { get; set; }
        public string Referenciadomiciliaria { get; set; }
        public string Email { get; set; }
        public int Secuencialtipoidentificacion { get; set; }
        public int Secuencialdivpolresidencia { get; set; }
        public string Codigopaisorigen { get; set; }
        public int Numeroverificador { get; set; }
        public int Secuencialdivactividadecon { get; set; }
        public string Codigosociomigra { get; set; }
        public string Identificacionmigra { get; set; }

        //public Cliente Cliente { get; set; }
        //public ICollection<Telefonopersona> Telefonopersona { get; set; }
        //public ICollection<UsuarioComplemento> UsuarioComplemento { get; set; }
        // public ICollection<UsuarioComplemento1> UsuarioComplemento1 { get; set; }
    }
}