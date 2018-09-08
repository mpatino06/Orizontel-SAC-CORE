using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SAC.CORE.API.ModelAdmin
{
    public partial class AdminTransaccionalContext : DbContext
    {
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioImagen> Usuarioimagen { get; set; }
        public virtual DbSet<UsuarioMovimiento> Usuariomovimiento { get; set; }
        public virtual DbSet<Afiliacion> Afiliacion { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }
        public virtual DbSet<Preguntaseguridad> Preguntaseguridad { get; set; }
        public virtual DbSet<Usuariopregunta> Usuariopregunta { get; set; }
        public virtual DbSet<Tiposervicio> Tiposervicio { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<PlazoFijoPeriodo> PlazoFijoPeriodo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

                var connectionStringConfig = builder.Build();

                optionsBuilder.UseSqlServer(connectionStringConfig.GetConnectionString("AdminConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Identificacion).HasMaxLength(40);

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.Clave).HasMaxLength(1000);

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasMaxLength(50);

                entity.Property(e => e.TextoImagen).HasMaxLength(50);
            });

            modelBuilder.Entity<UsuarioImagen>(entity =>
            {
                entity.HasKey(e => e.IdImagen);

                entity.Property(e => e.CodigoImagen);

                entity.Property(e => e.Ruta);

                entity.Property(e => e.Activo);
            });

            modelBuilder.Entity<UsuarioMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioMovimiento);

                entity.Property(e => e.IdUsuario);

                entity.Property(e => e.Fecha);

                entity.Property(e => e.Value1);

                entity.Property(e => e.Value2);

                entity.Property(e => e.Value3);

                entity.Property(e => e.Value4);

                entity.Property(e => e.Value5);
            });

            modelBuilder.Entity<Afiliacion>(entity =>
            {
                entity.HasKey(e => e.IdAfiliciacionCliente);

                entity.Property(e => e.IdentificacionUsuario);

                entity.Property(e => e.IdentificacionCliente);

                entity.Property(e => e.IdServicio);

                entity.Property(e => e.NombreBeneficiario);

                entity.Property(e => e.SecuencialCuenta);

                entity.Property(e => e.NombreAfiliacion);

                entity.Property(e => e.NumeroCuenta);

                entity.Property(e => e.CodigoBanco);

                entity.Property(e => e.Email);

                entity.Property(e => e.Fecha);

                entity.Property(e => e.MontoMaximo);

                entity.Property(e => e.EstaActivo);
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia);

                entity.Property(e => e.IdAfiliacioncliente);

                entity.Property(e => e.SecuencialCuentacliente);

                entity.Property(e => e.Fecha);

                entity.Property(e => e.SecuencialTransaccion);

                entity.Property(e => e.Valor);

                entity.Property(e => e.Descripcion);

                entity.Property(e => e.Documento);

                entity.Property(e => e.SaldoCuenta);

                entity.Property(e => e.SecuencialMovimiento);
            });

            modelBuilder.Entity<Preguntaseguridad>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Pregunta).HasColumnName("Pregunta");

                entity.Property(e => e.Idtiporespuesta).HasColumnName("IdTipoRespuesta");

                entity.Property(e => e.Activo).HasColumnName("Activo");
            });

            modelBuilder.Entity<Usuariopregunta>(entity =>
            {
                entity.HasKey(e => new { e.Idusuario, e.Idpregunta });

              //  entity.HasKey(e => e.Idpregunta);

                entity.Property(e => e.Respuesta).HasColumnName("Respuesta");
            });

            modelBuilder.Entity<Tiposervicio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).HasColumnName("Nombre");

                entity.Property(e => e.Orden).HasColumnName("Orden");

                entity.Property(e => e.Activo).HasColumnName("Activo");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).HasColumnName("Nombre");

                entity.Property(e => e.IdTipoServicio).HasColumnName("IdTipoServicio");

                entity.Property(e => e.Activo).HasColumnName("Activo");
            });

            modelBuilder.Entity<PlazoFijoPeriodo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).HasColumnName("Nombre");

                entity.Property(e => e.MinimoDias).HasColumnName("MinimoDias");

                entity.Property(e => e.MaximoDias).HasColumnName("MaximoDias");

                entity.Property(e => e.Activo).HasColumnName("Activo");
            });
        }
    }
}