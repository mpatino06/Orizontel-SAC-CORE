using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SAC.CORE.API.Models
{
    public partial class FBS_SacAmbatoContext : DbContext
    {
        public virtual DbSet<Calificacionprestamo> Calificacionprestamo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Estadoprestamo> Estadoprestamo { get; set; }
        public virtual DbSet<MovimientodetallePrestamocli> MovimientodetallePrestamocli { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Prestamocliente> Prestamocliente { get; set; }
        public virtual DbSet<PrestamocomponenteCartera> PrestamocomponenteCartera { get; set; }
        public virtual DbSet<PrestamocomponenteCartera1> PrestamocomponenteCartera1 { get; set; }
        public virtual DbSet<Prestamomaestro> Prestamomaestro { get; set; }
        public virtual DbSet<Prestamomaestro1> Prestamomaestro1 { get; set; }
        public virtual DbSet<Telefonopersona> Telefonopersona { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioComplemento> UsuarioComplemento { get; set; }
        public virtual DbSet<TipoPrestamo> TipoPrestamo { get; set; }
        public virtual DbSet<Movimientodetalleprestamo> Movimientodetalleprestamo { get; set; }
        public virtual DbSet<Personanatural> Personanatural { get; set; }
        public virtual DbSet<Estadocivil> Estadocivil { get; set; }
        public virtual DbSet<Tipoeducacion> Tipoeducacion { get; set; }
        public virtual DbSet<Tipovivienda> Tipovivienda { get; set; }
        public virtual DbSet<Profesion> Profesion { get; set; }
        public virtual DbSet<Condiciontablaamortizacion> Condiciontablaamortizacion { get; set; }
        public virtual DbSet<Segmentointerno> Segmentointerno { get; set; }
        public virtual DbSet<Subcalificacioncontable> Subcalificacioncontable { get; set; }
        public virtual DbSet<Solicitudmaestro> Solicitudmaestro { get; set; }
        public virtual DbSet<SolicitudmaestroPrestamo> SolicitudmaestroPrestamo { get; set; }
        public virtual DbSet<Estadosolicitud> Estadosolicitud { get; set; }
        public virtual DbSet<Tipoidentificacion> Tipoidentificacion { get; set; }
        public virtual DbSet<Cuentamaestro> Cuentamaestro { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<Movimientodetalle> Movimientodetalle { get; set; }
        public virtual DbSet<MovimientodetalleCuenta> MovimientodetalleCuenta { get; set; }
        public virtual DbSet<MovimientocuentacompVista> MovimientocuentacompVista { get; set; }
        public virtual DbSet<Depositomaestro> Depositomaestro { get; set; }
        public virtual DbSet<Depositocliente> Depositocliente { get; set; }
        public virtual DbSet<DepositocomponentePlazo> DepositocomponentePlazo { get; set; }
        public virtual DbSet<DepositocompPlazoRangotempz> DepositocompPlazoRangotempz { get; set; }
        public virtual DbSet<Rangotemporizacion> Rangotemporizacion { get; set; }
        public virtual DbSet<Depositobeneficiario> Depositobeneficiario { get; set; }
        public virtual DbSet<MovimientodepositocompPlazo> MovimientodepositocompPlazo { get; set; }
        public virtual DbSet<Depositodocumentofisico> Depositodocumentofisico { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

                var connectionStringConfig = builder.Build();

                //optionsBuilder.UseSqlServer(@"Data Source=192.168.251.250;DataBase=FBSSacAmbatoFullData; User Id=sa;Password=OR.2018*--");
                optionsBuilder.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacionprestamo>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("CALIFICACIONPRESTAMO", "FBS_CARTERA");

                entity.HasIndex(e => e.Fechacalificacion)
                    .HasName("IX_CALIFICACIONPRESTAMO");

                entity.HasIndex(e => new { e.Secuencialprestamo, e.Fechacalificacion })
                    .HasName("IX_00058")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigousuario)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20);

                entity.Property(e => e.Diasmorosidad).HasColumnName("DIASMOROSIDAD");

                entity.Property(e => e.Eshomologada).HasColumnName("ESHOMOLOGADA");

                entity.Property(e => e.Fechacalificacion)
                    .HasColumnName("FECHACALIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamaquina)
                    .HasColumnName("FECHAMAQUINA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Provisionautomatica).HasColumnName("PROVISIONAUTOMATICA");

                entity.Property(e => e.Provisionconstituida).HasColumnName("PROVISIONCONSTITUIDA");

                entity.Property(e => e.Provisionmanual).HasColumnName("PROVISIONMANUAL");

                entity.Property(e => e.Provisionoriginal).HasColumnName("PROVISIONORIGINAL");

                entity.Property(e => e.Saldoprestamo).HasColumnName("SALDOPRESTAMO");

                entity.Property(e => e.Secuencialcondcalifautoriginal).HasColumnName("SECUENCIALCONDCALIFAUTORIGINAL");

                entity.Property(e => e.Secuencialcondicioncalifaut).HasColumnName("SECUENCIALCONDICIONCALIFAUT");

                entity.Property(e => e.Secuencialcondicioncalifmanual).HasColumnName("SECUENCIALCONDICIONCALIFMANUAL");

                entity.Property(e => e.Secuencialprestamo).HasColumnName("SECUENCIALPRESTAMO");

                //entity.HasOne(d => d.CodigousuarioNavigation)
                //    .WithMany(p => p.Calificacionprestamo)
                //    .HasForeignKey(d => d.Codigousuario)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("CALIFICACIONPRESTAMO_R04");

                entity.HasOne(d => d.SecuencialprestamoNavigation)
                    .WithMany(p => p.Calificacionprestamo)
                    .HasForeignKey(d => d.Secuencialprestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CALIFICACIONPRESTAMO_R01");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("CLIENTE", "FBS_CLIENTES");

                entity.HasIndex(e => e.Numerocliente)
                    .HasName("IX_CLIENTE_1");

                entity.HasIndex(e => e.Secuencialpersona)
                    .HasName("IX_CLIENTE")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigocalificacioninterna)
                    .IsRequired()
                    .HasColumnName("CODIGOCALIFICACIONINTERNA")
                    .HasMaxLength(2);

                entity.Property(e => e.Codigoestadocliente)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOCLIENTE")
                    .HasMaxLength(2);

                entity.Property(e => e.Codigosectoreconomico)
                    .IsRequired()
                    .HasColumnName("CODIGOSECTORECONOMICO")
                    .HasMaxLength(8);

                entity.Property(e => e.Codigotipovinculacion)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOVINCULACION")
                    .HasMaxLength(6);

                entity.Property(e => e.Codigousuariooficial)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIOOFICIAL")
                    .HasMaxLength(20);

                entity.Property(e => e.Fechaingreso)
                    .HasColumnName("FECHAINGRESO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numerocliente).HasColumnName("NUMEROCLIENTE");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialdivisionmercado).HasColumnName("SECUENCIALDIVISIONMERCADO");

                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");

                entity.Property(e => e.Secuencialpersona).HasColumnName("SECUENCIALPERSONA");

                //entity.HasOne(d => d.CodigousuariooficialNavigation)
                //    .WithMany(p => p.Cliente)
                //    .HasForeignKey(d => d.Codigousuariooficial)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("CLIENTE_R03");

                //entity.HasOne(d => d.SecuencialpersonaNavigation)
                //    .WithOne(p => p.Cliente)
                //    .HasForeignKey<Cliente>(d => d.Secuencialpersona)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("CLIENTE_R02");
            });

            modelBuilder.Entity<Estadoprestamo>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("ESTADOPRESTAMO", "FBS_CARTERA");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.Color).HasColumnName("COLOR");

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("IMAGEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
            });

            modelBuilder.Entity<MovimientodetallePrestamocli>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("MOVIMIENTODETALLE_PRESTAMOCLI", "FBS_CARTERA");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Secuencialmovdetalleprestamo).HasColumnName("SECUENCIALMOVDETALLEPRESTAMO");

                entity.Property(e => e.Secuencialprestamocliente).HasColumnName("SECUENCIALPRESTAMOCLIENTE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.SecuencialprestamoclienteNavigation)
                    .WithMany(p => p.MovimientodetallePrestamocli)
                    .HasForeignKey(d => d.Secuencialprestamocliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MOVIMIENTODETALLE_PRESTAMX_R02");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("PERSONA", "FBS_PERSONAS");

                entity.HasIndex(e => e.Identificacion)
                    .HasName("IX_PERSONA");

                entity.HasIndex(e => new { e.Secuencialtipoidentificacion, e.Identificacion })
                    .HasName("IX_01")
                    .IsUnique();

                entity.HasIndex(e => new { e.Identificacion, e.Nombreunido, e.Secuencial })
                    .HasName("_dta_index_PERSONA_14_1929318183__K1_2_3");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigopaisorigen)
                    .IsRequired()
                    .HasColumnName("CODIGOPAISORIGEN")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigosociomigra)
                    .HasColumnName("CODIGOSOCIOMIGRA")
                    .HasColumnType("nchar(255)");

                entity.Property(e => e.Direcciondomicilio)
                    .IsRequired()
                    .HasColumnName("DIRECCIONDOMICILIO")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(70);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasColumnName("IDENTIFICACION")
                    .HasMaxLength(40);

                entity.Property(e => e.Identificacionmigra)
                    .HasColumnName("IDENTIFICACIONMIGRA")
                    .HasMaxLength(255);

                entity.Property(e => e.Nombreunido)
                    .IsRequired()
                    .HasColumnName("NOMBREUNIDO")
                    .HasMaxLength(200);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Referenciadomiciliaria)
                    .IsRequired()
                    .HasColumnName("REFERENCIADOMICILIARIA")
                    .HasMaxLength(300);

                entity.Property(e => e.Secuencialdivactividadecon).HasColumnName("SECUENCIALDIVACTIVIDADECON");

                entity.Property(e => e.Secuencialdivpolresidencia).HasColumnName("SECUENCIALDIVPOLRESIDENCIA");

                entity.Property(e => e.Secuencialtipoidentificacion).HasColumnName("SECUENCIALTIPOIDENTIFICACION");
            });

            modelBuilder.Entity<Prestamocliente>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("PRESTAMOCLIENTE", "FBS_CARTERA");

                entity.HasIndex(e => e.Secuencialcliente)
                    .HasName("IX_PRESTAMOCLIENTE");

                entity.HasIndex(e => e.Secuencialprestamo)
                    .HasName("IX_PRESTAMOCLIENTE_1");

                entity.HasIndex(e => new { e.Secuencialcliente, e.Secuencialprestamo })
                    .HasName("IX_00071")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Esprincipal).HasColumnName("ESPRINCIPAL");

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialcliente).HasColumnName("SECUENCIALCLIENTE");

                entity.Property(e => e.Secuencialprestamo).HasColumnName("SECUENCIALPRESTAMO");

                entity.HasOne(d => d.SecuencialclienteNavigation)
                    .WithMany(p => p.Prestamocliente)
                    .HasForeignKey(d => d.Secuencialcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESTAMOCLIENTE_R02");

                entity.HasOne(d => d.SecuencialprestamoNavigation)
                    .WithMany(p => p.Prestamocliente)
                    .HasForeignKey(d => d.Secuencialprestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESTAMOCLIENTE_R01");
            });

            modelBuilder.Entity<PrestamocomponenteCartera>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("PRESTAMOCOMPONENTE_CARTERA", "FBS_CARTERA");

                entity.HasIndex(e => e.Secuencialprestamo)
                    .HasName("IX_PRESTAMOCOMPONENTE_CARTERA");

                entity.HasIndex(e => new { e.Secuencialprestamo, e.Secuencialcomponentecartera })
                    .HasName("IX_PRESTAMOCOMPONENTE_CARTERA_2");

                entity.HasIndex(e => new { e.Secuencialprestamo, e.Secuencialcomponentecartera, e.Numerocuota })
                    .HasName("IX_00078")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigoestadoprestamocomponente)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOPRESTAMOCOMPONENTE")
                    .HasMaxLength(4);

                entity.Property(e => e.Diascalculados).HasColumnName("DIASCALCULADOS");

                entity.Property(e => e.Factorcalculo).HasColumnName("FACTORCALCULO");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("FECHAINICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnName("FECHAVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numerocuota).HasColumnName("NUMEROCUOTA");

                entity.Property(e => e.Secuencialcomponentecartera).HasColumnName("SECUENCIALCOMPONENTECARTERA");

                entity.Property(e => e.Secuencialprestamo).HasColumnName("SECUENCIALPRESTAMO");

                entity.Property(e => e.Valorcalculado)
                    .HasColumnName("VALORCALCULADO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Valorcobrado)
                    .HasColumnName("VALORCOBRADO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Valorproyectado)
                    .HasColumnName("VALORPROYECTADO")
                    .HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.SecuencialprestamoNavigation)
                    .WithMany(p => p.PrestamocomponenteCartera)
                    .HasForeignKey(d => d.Secuencialprestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESTAMOCOMPONENTE_CARTERA_R01");
            });

            modelBuilder.Entity<PrestamocomponenteCartera1>(entity =>
            {
                entity.HasKey(e => new { e.Fechahistorico, e.Secuencial });

                entity.ToTable("PRESTAMOCOMPONENTE_CARTERA", "FBS_HISTORICOS");

                entity.HasIndex(e => new { e.Fechahistorico, e.Fechamodifica, e.Secuencialprestamo, e.Secuencialcomponentecartera })
                    .HasName("NonClusteredIndex-20141006-110712");

                entity.HasIndex(e => new { e.Fechahistorico, e.Fechamodifica, e.Secuencialprestamo, e.Secuencialcomponentecartera, e.Codigoestadoprestamocomponente })
                    .HasName("NonClusteredIndex-20141006-110742");

                entity.Property(e => e.Fechahistorico)
                    .HasColumnName("FECHAHISTORICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigoestadoprestamocomponente)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOPRESTAMOCOMPONENTE")
                    .HasMaxLength(4);

                entity.Property(e => e.Diascalculados).HasColumnName("DIASCALCULADOS");

                entity.Property(e => e.Factorcalculo).HasColumnName("FACTORCALCULO");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("FECHAINICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamodifica)
                    .HasColumnName("FECHAMODIFICA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnName("FECHAVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numerocuota).HasColumnName("NUMEROCUOTA");

                entity.Property(e => e.Secuencialcomponentecartera).HasColumnName("SECUENCIALCOMPONENTECARTERA");

                entity.Property(e => e.Secuencialprestamo).HasColumnName("SECUENCIALPRESTAMO");

                entity.Property(e => e.Valorcalculado)
                    .HasColumnName("VALORCALCULADO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Valorcobrado)
                    .HasColumnName("VALORCOBRADO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Valorproyectado)
                    .HasColumnName("VALORPROYECTADO")
                    .HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<Prestamomaestro>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("PRESTAMOMAESTRO", "FBS_CARTERA");

                entity.HasIndex(e => e.Numeropagare)
                    .HasName("IX_PRESTAMOMAESTRO");

                entity.HasIndex(e => e.Numeroprestamo)
                    .HasName("IX_PRESTAMOMAESTRO_1");

                entity.HasIndex(e => new { e.Numeroprestamo, e.Secuencialempresa })
                    .HasName("IX_00082")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Bloqueadotransaccionoperativa).HasColumnName("BLOQUEADOTRANSACCIONOPERATIVA");

                entity.Property(e => e.Calificacionactual)
                    .IsRequired()
                    .HasColumnName("CALIFICACIONACTUAL")
                    .HasMaxLength(2);

                entity.Property(e => e.Calificacionpeor)
                    .IsRequired()
                    .HasColumnName("CALIFICACIONPEOR")
                    .HasMaxLength(2);

                entity.Property(e => e.Cobraporrol).HasColumnName("COBRAPORROL");

                entity.Property(e => e.Codigoestadoprestamo)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOPRESTAMO")
                    .HasMaxLength(4);

                entity.Property(e => e.Codigoproductocartera)
                    .IsRequired()
                    .HasColumnName("CODIGOPRODUCTOCARTERA")
                    .HasMaxLength(40);

                entity.Property(e => e.Codigosubcalificacioncontable)
                    .IsRequired()
                    .HasColumnName("CODIGOSUBCALIFICACIONCONTABLE")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigotipoprestamo)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOPRESTAMO")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigousuariooficial)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIOOFICIAL")
                    .HasMaxLength(20);

                entity.Property(e => e.Deudainicial).HasColumnName("DEUDAINICIAL");

                entity.Property(e => e.Diasreajuste).HasColumnName("DIASREAJUSTE");

                entity.Property(e => e.Estavigenteclasificacion).HasColumnName("ESTAVIGENTECLASIFICACION");

                entity.Property(e => e.Fechaadjudicacion)
                    .HasColumnName("FECHAADJUDICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechacorte)
                    .HasColumnName("FECHACORTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnName("FECHAVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Frecuenciapago).HasColumnName("FRECUENCIAPAGO");

                entity.Property(e => e.Identificacionsujetooriginal)
                    .IsRequired()
                    .HasColumnName("IDENTIFICACIONSUJETOORIGINAL")
                    .HasMaxLength(15);

                entity.Property(e => e.Numerocuotas).HasColumnName("NUMEROCUOTAS");

                entity.Property(e => e.Numeropagare)
                    .IsRequired()
                    .HasColumnName("NUMEROPAGARE")
                    .HasMaxLength(40);

                entity.Property(e => e.Numeroprestamo)
                    .IsRequired()
                    .HasColumnName("NUMEROPRESTAMO")
                    .HasMaxLength(40);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Saldoactual).HasColumnName("SALDOACTUAL");

                entity.Property(e => e.Secuencialcondiciontablaamortz).HasColumnName("SECUENCIALCONDICIONTABLAAMORTZ");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");

                entity.Property(e => e.Secuencialmoneda).HasColumnName("SECUENCIALMONEDA");

                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");

                entity.Property(e => e.Secuencialsegmentointerno).HasColumnName("SECUENCIALSEGMENTOINTERNO");

                entity.Property(e => e.Sereajusta).HasColumnName("SEREAJUSTA");

                entity.Property(e => e.Teaconseguro).HasColumnName("TEACONSEGURO");

                entity.Property(e => e.Teasinseguro).HasColumnName("TEASINSEGURO");

                entity.Property(e => e.Valorentregado).HasColumnName("VALORENTREGADO");

                entity.HasOne(d => d.CodigoestadoprestamoNavigation)
                    .WithMany(p => p.Prestamomaestro)
                    .HasForeignKey(d => d.Codigoestadoprestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRESTAMOMAESTRO_R08");

                //entity.HasOne(d => d.CodigousuariooficialNavigation)
                //    .WithMany(p => p.Prestamomaestro)
                //    .HasForeignKey(d => d.Codigousuariooficial)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("PRESTAMOMAESTRO_R09");
            });

            modelBuilder.Entity<Prestamomaestro1>(entity =>
            {
                entity.HasKey(e => new { e.Fechahistorico, e.Secuencial });

                entity.ToTable("PRESTAMOMAESTRO", "FBS_HISTORICOS");

                entity.Property(e => e.Fechahistorico)
                    .HasColumnName("FECHAHISTORICO")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Bloqueadotransaccionoperativa).HasColumnName("BLOQUEADOTRANSACCIONOPERATIVA");

                entity.Property(e => e.Calificacionactual)
                    .IsRequired()
                    .HasColumnName("CALIFICACIONACTUAL")
                    .HasMaxLength(2);

                entity.Property(e => e.Calificacionpeor)
                    .IsRequired()
                    .HasColumnName("CALIFICACIONPEOR")
                    .HasMaxLength(2);

                entity.Property(e => e.Cobraporrol).HasColumnName("COBRAPORROL");

                entity.Property(e => e.Codigoestadoprestamo)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOPRESTAMO")
                    .HasMaxLength(4);

                entity.Property(e => e.Codigoproductocartera)
                    .IsRequired()
                    .HasColumnName("CODIGOPRODUCTOCARTERA")
                    .HasMaxLength(40);

                entity.Property(e => e.Codigosubcalificacioncontable)
                    .IsRequired()
                    .HasColumnName("CODIGOSUBCALIFICACIONCONTABLE")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigotipoprestamo)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOPRESTAMO")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigousuariooficial)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIOOFICIAL")
                    .HasMaxLength(20);

                entity.Property(e => e.Deudainicial).HasColumnName("DEUDAINICIAL");

                entity.Property(e => e.Diasreajuste).HasColumnName("DIASREAJUSTE");

                entity.Property(e => e.Estavigenteclasificacion).HasColumnName("ESTAVIGENTECLASIFICACION");

                entity.Property(e => e.Fechaadjudicacion)
                    .HasColumnName("FECHAADJUDICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechacorte)
                    .HasColumnName("FECHACORTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamodifica)
                    .HasColumnName("FECHAMODIFICA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnName("FECHAVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Frecuenciapago).HasColumnName("FRECUENCIAPAGO");

                entity.Property(e => e.Identificacionsujetooriginal)
                    .HasColumnName("IDENTIFICACIONSUJETOORIGINAL")
                    .HasMaxLength(15);

                entity.Property(e => e.Numerocuotas).HasColumnName("NUMEROCUOTAS");

                entity.Property(e => e.Numeropagare)
                    .HasColumnName("NUMEROPAGARE")
                    .HasMaxLength(40);

                entity.Property(e => e.Numeroprestamo)
                    .IsRequired()
                    .HasColumnName("NUMEROPRESTAMO")
                    .HasMaxLength(40);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Saldoactual).HasColumnName("SALDOACTUAL");

                entity.Property(e => e.Secuencialcondiciontablaamortz).HasColumnName("SECUENCIALCONDICIONTABLAAMORTZ");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");

                entity.Property(e => e.Secuencialmoneda).HasColumnName("SECUENCIALMONEDA");

                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");

                entity.Property(e => e.Secuencialsegmentointerno).HasColumnName("SECUENCIALSEGMENTOINTERNO");

                entity.Property(e => e.Sereajusta).HasColumnName("SEREAJUSTA");

                entity.Property(e => e.Teaconseguro).HasColumnName("TEACONSEGURO");

                entity.Property(e => e.Teasinseguro).HasColumnName("TEASINSEGURO");

                entity.Property(e => e.Valorentregado).HasColumnName("VALORENTREGADO");
            });

            modelBuilder.Entity<Telefonopersona>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("TELEFONOPERSONA", "FBS_PERSONAS");

                entity.HasIndex(e => e.Secuencialpersona)
                    .HasName("IX_TELEFONOPERSONA");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigoempresatelefonica)
                    .IsRequired()
                    .HasColumnName("CODIGOEMPRESATELEFONICA")
                    .HasMaxLength(6);

                entity.Property(e => e.Codigotipotelefono)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOTELEFONO")
                    .HasMaxLength(2);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(200);

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Numerotelefono)
                    .IsRequired()
                    .HasColumnName("NUMEROTELEFONO")
                    .HasMaxLength(40);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialpersona).HasColumnName("SECUENCIALPERSONA");

                //entity.HasOne(d => d.SecuencialpersonaNavigation)
                //    .WithMany(p => p.Telefonopersona)
                //    .HasForeignKey(d => d.Secuencialpersona)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("TELEFONOPERSONA_R03");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("USUARIO", "FBS_SEGURIDADES");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");
            });

            modelBuilder.Entity<UsuarioComplemento>(entity =>
            {
                entity.HasKey(e => e.Codigousuario);

                entity.ToTable("USUARIO_COMPLEMENTO", "FBS_SEGURIDADES");

                entity.Property(e => e.Codigousuario)
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cambioclaveproximoingreso).HasColumnName("CAMBIOCLAVEPROXIMOINGRESO");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("CLAVE")
                    .HasMaxLength(1000);

                entity.Property(e => e.Emailinterno)
                    .IsRequired()
                    .HasColumnName("EMAILINTERNO")
                    .HasMaxLength(200);

                entity.Property(e => e.Esinterno).HasColumnName("ESINTERNO");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("FECHACREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechaultimocambioclave)
                    .HasColumnName("FECHAULTIMOCAMBIOCLAVE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Periodicidadcambioclave).HasColumnName("PERIODICIDADCAMBIOCLAVE");

                entity.Property(e => e.Puedeconsultarotrosusuarios).HasColumnName("PUEDECONSULTAROTROSUSUARIOS");

                entity.Property(e => e.Secuencialpersona).HasColumnName("SECUENCIALPERSONA");

                entity.HasOne(d => d.CodigousuarioNavigation)
                    .WithOne(p => p.UsuarioComplemento)
                    .HasForeignKey<UsuarioComplemento>(d => d.Codigousuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0031868");

                //entity.HasOne(d => d.SecuencialpersonaNavigation)
                //    .WithMany(p => p.UsuarioComplemento)
                //    .HasForeignKey(d => d.Secuencialpersona)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("USUARIO_COMPLEMENTO_R01");
            });

            modelBuilder.Entity<TipoPrestamo>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("TIPOPRESTAMO", "FBS_CREDITO");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Siglas).HasColumnName("SIGLAS");
                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
                entity.Property(e => e.Plazominimo).HasColumnName("PLAZOMINIMO");
                entity.Property(e => e.Plazomaximo).HasColumnName("PLAZOMAXIMO");
                entity.Property(e => e.Montominimo).HasColumnName("MONTOMINIMO");
                entity.Property(e => e.Montomaximo).HasColumnName("MONTOMAXIMO");
                entity.Property(e => e.Calificacionminimasolsobrediez).HasColumnName("CALIFICACIONMINIMASOLSOBREDIEZ");
                entity.Property(e => e.Escobrohorizontal).HasColumnName("ESCOBROHORIZONTAL");
                entity.Property(e => e.Numerominimodeudores).HasColumnName("NUMEROMINIMODEUDORES");
                entity.Property(e => e.Numeromaximodeudores).HasColumnName("NUMEROMAXIMODEUDORES");
                entity.Property(e => e.Frecuenciarestringida).HasColumnName("FRECUENCIARESTRINGIDA");
                entity.Property(e => e.Nivelcontable).HasColumnName("NIVELCONTABLE");
                entity.Property(e => e.Diasminimoreajuste).HasColumnName("DIASMINIMOREAJUSTE");
                entity.Property(e => e.Esoperativo).HasColumnName("ESOPERATIVO");
                entity.Property(e => e.Nombremetodoobtienecalifgrupo).HasColumnName("NOMBREMETODOOBTIENECALIFGRUPO");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Numerodiasmoraavalidar).HasColumnName("NUMERODIASMORAAVALIDAR");
                entity.Property(e => e.Esparabacktoback).HasColumnName("ESPARABACKTOBACK");
                entity.Property(e => e.Aceptalineacredito).HasColumnName("ACEPTALINEACREDITO");
                entity.Property(e => e.Aceptacuotasdegracia).HasColumnName("ACEPTACUOTASDEGRACIA");
            });

            modelBuilder.Entity<Movimientodetalleprestamo>(entity =>
            {
                entity.HasKey(e => e.Secuencialmovimientodetalle);

                entity.ToTable("MOVIMIENTODETALLE_PRESTAMO", "FBS_CARTERA");

                entity.Property(e => e.Secuencialmovimientodetalle).HasColumnName("SECUENCIALMOVIMIENTODETALLE");

                entity.Property(e => e.Secuencialprestamo).HasColumnName("SECUENCIALPRESTAMO");

                entity.Property(e => e.Saldoprestamo).HasColumnName("SALDOPRESTAMO");

                entity.Property(e => e.Codigoestadoprestamo).HasColumnName("CODIGOESTADOPRESTAMO");
            });

            modelBuilder.Entity<Personanatural>(entity =>
            {
                entity.HasKey(e => e.Secuencialpersona);
                entity.ToTable("PERSONA_NATURAL", "FBS_PERSONAS");

                entity.Property(e => e.Secuencialpersona).HasColumnName("SECUENCIALPERSONA");
                entity.Property(e => e.Apellidos).HasColumnName("APELLIDOS");
                entity.Property(e => e.Nombres).HasColumnName("NOMBRES");
                entity.Property(e => e.FechaNacimiento).HasColumnName("FECHANACIMIENTO");
                entity.Property(e => e.Esmasculino).HasColumnName("ESMASCULINO");
                entity.Property(e => e.Codigoestadocivil).HasColumnName("CODIGOESTADOCIVIL");
                entity.Property(e => e.Codigotipoeducacion).HasColumnName("CODIGOTIPOEDUCACION");
                entity.Property(e => e.Codigotipovivienda).HasColumnName("CODIGOTIPOVIVIENDA");
                entity.Property(e => e.Codigoprofesion).HasColumnName("CODIGOPROFESION");
                entity.Property(e => e.Egresosmensuales).HasColumnName("EGRESOSMENSUALES");
                entity.Property(e => e.Patrimonio).HasColumnName("PATRIMONIO");
                entity.Property(e => e.ApellidoPaterno).HasColumnName("APELLIDOPATERNO");
                entity.Property(e => e.ApellidoMaterno).HasColumnName("APELLIDOMATERNO");
                entity.Property(e => e.Primernombre).HasColumnName("PRIMERNOMBRE");
                entity.Property(e => e.Segundonombre).HasColumnName("SEGUNDONOMBRE");
                entity.Property(e => e.Lugarnacimiento).HasColumnName("LUGARNACIMIENTO");
                entity.Property(e => e.Activostotales).HasColumnName("ACTIVOSTOTALES");
                entity.Property(e => e.Pasivostotales).HasColumnName("PASIVOSTOTALES");
                entity.Property(e => e.Cargasfamiliares).HasColumnName("CARGASFAMILIARES");
            });

            modelBuilder.Entity<Estadocivil>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("ESTADOCIVIL", "FBS_PERSONAS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.RequiereConyugue).HasColumnName("REQUIERECONYUGE");
                entity.Property(e => e.EstaActivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.NumeroVerificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Codigosbs).HasColumnName("CODIGOSBS");
            });

            modelBuilder.Entity<Tipoeducacion>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("TIPOEDUCACION", "FBS_PERSONAS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Aceptaprofesion).HasColumnName("ACEPTAPROFESION");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Codigosbs).HasColumnName("CODIGOSBS");
            });

            modelBuilder.Entity<Tipovivienda>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("TIPOVIVIENDA", "FBS_PERSONAS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Esperteneciente).HasColumnName("ESPERTENECIENTE");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Codigosbs).HasColumnName("CODIGOSBS");
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("PROFESION", "FBS_PERSONAS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Codigosbs).HasColumnName("CODIGOSBS");
            });

            modelBuilder.Entity<Condiciontablaamortizacion>(entity =>
            {
                entity.HasKey(e => e.Secuencial);
                entity.ToTable("CONDICIONTABLAAMORTIZACION", "FBS_CREDITO");

                entity.Property(e => e.Escuotafija).HasColumnName("ESCUOTAFIJA");
                entity.Property(e => e.Codigogeneracionvenccuota).HasColumnName("CODIGOGENERACIONVENCCUOTA");
                entity.Property(e => e.Esconalicuota).HasColumnName("ESCONALICUOTA");
                entity.Property(e => e.Esinteresessobresaldo).HasColumnName("ESINTERESSOBRESALDOS");
                entity.Property(e => e.Aumentaprimeracuota).HasColumnName("AUMENTAPRIMERACUOTA");
                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Condiciontablaamortizacion>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("CONDICIONTABLAAMORTIZACION", "FBS_CREDITO");

                entity.HasIndex(e => new { e.Escuotafija, e.Codigogeneracionvenccuota, e.Secuencialempresa, e.Esconalicuota })
                    .HasName("IX_000132")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Aumentaprimeracuota).HasColumnName("AUMENTAPRIMERACUOTA");

                entity.Property(e => e.Codigogeneracionvenccuota)
                    .IsRequired()
                    .HasColumnName("CODIGOGENERACIONVENCCUOTA")
                    .HasMaxLength(40);

                entity.Property(e => e.Esconalicuota).HasColumnName("ESCONALICUOTA");

                entity.Property(e => e.Escuotafija).HasColumnName("ESCUOTAFIJA");

                entity.Property(e => e.Esinteresessobresaldo).HasColumnName("ESINTERESSOBRESALDOS");

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(20);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
            });

            modelBuilder.Entity<Segmentointerno>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("SEGMENTOINTERNO", "FBS_CREDITO");

                entity.HasIndex(e => new { e.Codigocalificacioncontable, e.Codigodestinofinanciero, e.Secuencialempresa })
                    .HasName("IX_000150")
                    .IsUnique();

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigocalificacioncontable)
                    .IsRequired()
                    .HasColumnName("CODIGOCALIFICACIONCONTABLE")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigodestinofinanciero)
                    .IsRequired()
                    .HasColumnName("CODIGODESTINOFINANCIERO")
                    .HasMaxLength(20);

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
            });

            modelBuilder.Entity<Subcalificacioncontable>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("SUBCALIFICACIONCONTABLE", "FBS_CREDITO");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigocalificacioncontable)
                    .IsRequired()
                    .HasColumnName("CODIGOCALIFICACIONCONTABLE")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigosbs)
                    .HasColumnName("CODIGOSBS")
                    .HasMaxLength(2);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(400);

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasColumnName("SIGLAS")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Solicitudmaestro>(entity =>
            {
                entity.HasKey(e => e.Secuencial);
                entity.ToTable("SOLICITUDMAESTRO", "FBS_CREDITO");

                entity.Property(e => e.Numerosolicitud).HasColumnName("NUMEROSOLICITUD");
                entity.Property(e => e.Montosolicitado).HasColumnName("MONTOSOLICITADO");
                entity.Property(e => e.Montoaprobado).HasColumnName("MONTOAPROBADO");
                entity.Property(e => e.Fechaingreso).HasColumnName("FECHAINGRESO");
                entity.Property(e => e.Codigoestadosolicitud).HasColumnName("CODIGOESTADOSOLICITUD");
                entity.Property(e => e.Codigousuarioingreso).HasColumnName("CODIGOUSUARIOINGRESO");
                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");
                entity.Property(e => e.Esrenovacion).HasColumnName("ESRENOVACION");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Numeroprestamomigra).HasColumnName("NUMEROPRESTAMOMIGRA");
                entity.Property(e => e.Numerosociomigra).HasColumnName("NUMEROSOCIOMIGRA");
            });

            modelBuilder.Entity<SolicitudmaestroPrestamo>(entity =>
            {
                entity.HasKey(e => e.Secuencialsolicitud);
                entity.ToTable("SOLICITUDMAESTRO_PRESTAMO", "FBS_CREDITO");

                entity.Property(e => e.Secuencialsolicitud).HasColumnName("SECUENCIALSOLICITUD");
                entity.Property(e => e.Codigotipoprestamo).HasColumnName("CODIGOTIPOPRESTAMO");
                entity.Property(e => e.Codigoproductocartera).HasColumnName("CODIGOPRODUCTOCARTERA");
                entity.Property(e => e.Secuencialsegmentointerno).HasColumnName("SECUENCIALSEGMENTOINTERNO");
                entity.Property(e => e.Secuencialcondiciontablaamortz).HasColumnName("SECUENCIALCONDICIONTABLAAMORTZ");
                entity.Property(e => e.Codigosubcalificacioncontable).HasColumnName("CODIGOSUBCALIFICACIONCONTABLE");
                entity.Property(e => e.Frecuenciapago).HasColumnName("FRECUENCIAPAGO");
                entity.Property(e => e.Numerocuotas).HasColumnName("NUMEROCUOTAS");
                entity.Property(e => e.Cobraporrol).HasColumnName("COBRAPORROL");
                entity.Property(e => e.Codigoorigenrecurso).HasColumnName("CODIGOORIGENRECURSO");
            });

            modelBuilder.Entity<Estadosolicitud>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.ToTable("ESTADOSOLICITUD", "FBS_CREDITO");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
            });

            modelBuilder.Entity<Tipoidentificacion>(entity =>
            {
                entity.HasKey(e => e.Secuencial);
                entity.ToTable("TIPOIDENTIFICACION", "FBS_PERSONAS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Parapersonanatural).HasColumnName("PARAPERSONANATURAL");
                entity.Property(e => e.Numerominimorepresentantes).HasColumnName("NUMEROMINIMOREPRESENTANTES");
                entity.Property(e => e.Numerominimoreferenciaspersonas).HasColumnName("NUMEROMINIMOREFERENCIASPERSONA");
                entity.Property(e => e.Numerominimoreferenciasbancari).HasColumnName("NUMEROMINIMOREFERENCIASBANCARI");
                entity.Property(e => e.Numerominimoreferenciascomerci).HasColumnName("NUMEROMINIMOREFERENCIASCOMERCI");
                entity.Property(e => e.Estaactiva).HasColumnName("ESTAACTIVA");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
                entity.Property(e => e.Codigosbs).HasColumnName("CODIGOSBS");
            });

            modelBuilder.Entity<Cuentamaestro>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("CUENTAMAESTRO", "FBS_CAPTACIONESVISTA");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");
                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Codigotipocuenta).HasColumnName("CODIGOTIPOCUENTA");
                entity.Property(e => e.Codigoproductovista).HasColumnName("CODIGOPRODUCTOVISTA");
                entity.Property(e => e.Codigoestado).HasColumnName("CODIGOESTADO");
                entity.Property(e => e.Secuencialmoneda).HasColumnName("SECUENCIALMONEDA");
                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");
                entity.Property(e => e.Codigousuariooficial).HasColumnName("CODIGOUSUARIOOFICIAL");
                entity.Property(e => e.Fechasistemacreacion).HasColumnName("FECHASISTEMACREACION");
                entity.Property(e => e.Fechamaquinacreacion).HasColumnName("FECHAMAQUINACREACION");
                entity.Property(e => e.Numerolibreta).HasColumnName("NUMEROLIBRETA");
                entity.Property(e => e.Numeroimprimelibreta).HasColumnName("NUMEROLINEAIMPRIMELIBRETA");
                entity.Property(e => e.Esanverso).HasColumnName("ESANVERSO");
                entity.Property(e => e.Tieneseguroactivo).HasColumnName("TIENESEGUROACTIVO");
                entity.Property(e => e.Fechacorte).HasColumnName("FECHACORTE");
                entity.Property(e => e.Bloqueadatransaccionoperativa).HasColumnName("BLOQUEADATRANSACCIONOPERATIVA");
                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("MOVIMIENTO", "FBS_NEGOCIOSFINANCIEROS");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigousuario)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("DOCUMENTO")
                    .HasMaxLength(100);

                entity.Property(e => e.Estaimpreso).HasColumnName("ESTAIMPRESO");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamaquina)
                    .HasColumnName("FECHAMAQUINA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialoficinausuario).HasColumnName("SECUENCIALOFICINAUSUARIO");
            });

            modelBuilder.Entity<Movimientodetalle>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("MOVIMIENTODETALLE", "FBS_NEGOCIOSFINANCIEROS");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Secuencialmoneda).HasColumnName("SECUENCIALMONEDA");

                entity.Property(e => e.Secuencialmovimiento).HasColumnName("SECUENCIALMOVIMIENTO");

                entity.Property(e => e.Secuencialoficinaafectada).HasColumnName("SECUENCIALOFICINAAFECTADA");

                entity.Property(e => e.Secuencialtransaccion).HasColumnName("SECUENCIALTRANSACCION");

                entity.Property(e => e.Valor).HasColumnName("VALOR");
            });

            modelBuilder.Entity<MovimientodetalleCuenta>(entity =>
            {
                entity.HasKey(e => e.Secuencialmovimientodetalle);

                entity.ToTable("MOVIMIENTODETALLE_CUENTA", "FBS_CAPTACIONESVISTA");

                entity.Property(e => e.Secuencialmovimientodetalle)
                    .HasColumnName("SECUENCIALMOVIMIENTODETALLE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigoestadocuenta)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADOCUENTA")
                    .HasMaxLength(2);

                entity.Property(e => e.Saldocuenta).HasColumnName("SALDOCUENTA");

                entity.Property(e => e.Secuencialcuenta).HasColumnName("SECUENCIALCUENTA");
            });

            modelBuilder.Entity<MovimientocuentacompVista>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("MOVIMIENTOCUENTACOMP_VISTA", "FBS_CAPTACIONESVISTA");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigotipomovimiento)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOMOVIMIENTO")
                    .HasMaxLength(30);

                entity.Property(e => e.Saldo).HasColumnName("SALDO");

                entity.Property(e => e.Saldocuenta).HasColumnName("SALDOCUENTA");

                entity.Property(e => e.Secuencialcomponentevista).HasColumnName("SECUENCIALCOMPONENTEVISTA");

                entity.Property(e => e.Secuencialcuenta).HasColumnName("SECUENCIALCUENTA");

                entity.Property(e => e.Secuencialmovimientodetalle).HasColumnName("SECUENCIALMOVIMIENTODETALLE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");
            });

            modelBuilder.Entity<Depositomaestro>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("DEPOSITOMAESTRO", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("CODIGO")
                    .HasMaxLength(40);

                entity.Property(e => e.Codigoestadodeposito)
                    .IsRequired()
                    .HasColumnName("CODIGOESTADODEPOSITO")
                    .HasMaxLength(2);

                entity.Property(e => e.Codigoproductoplazo)
                    .IsRequired()
                    .HasColumnName("CODIGOPRODUCTOPLAZO")
                    .HasMaxLength(40);

                entity.Property(e => e.Codigotipodeposito)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPODEPOSITO")
                    .HasMaxLength(20);

                entity.Property(e => e.Codigousuario)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20);

                entity.Property(e => e.Fechacorte)
                    .HasColumnName("FECHACORTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("FECHACREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechamaquinacreacion)
                    .HasColumnName("FECHAMAQUINACREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechavencimiento)
                    .HasColumnName("FECHAVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Identificacionsujetooriginal)
                    .HasColumnName("IDENTIFICACIONSUJETOORIGINAL")
                    .HasMaxLength(15);

                entity.Property(e => e.Monto).HasColumnName("MONTO");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Pagoperiodicointeres).HasColumnName("PAGOPERIODICOINTERES");

                entity.Property(e => e.Plazoendias).HasColumnName("PLAZOENDIAS");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");

                entity.Property(e => e.Secuencialmoneda).HasColumnName("SECUENCIALMONEDA");

                entity.Property(e => e.Secuencialoficina).HasColumnName("SECUENCIALOFICINA");

                entity.Property(e => e.Tasa).HasColumnName("TASA");

                entity.Property(e => e.Variaciontasa).HasColumnName("VARIACIONTASA");
            });

            modelBuilder.Entity<Depositocliente>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("DEPOSITOCLIENTE", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Esconjunto).HasColumnName("ESCONJUNTO");

                entity.Property(e => e.Esprincipal).HasColumnName("ESPRINCIPAL");

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialcliente).HasColumnName("SECUENCIALCLIENTE");

                entity.Property(e => e.Secuencialdeposito).HasColumnName("SECUENCIALDEPOSITO");
            });

            modelBuilder.Entity<DepositocomponentePlazo>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("DEPOSITOCOMPONENTE_PLAZO", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigotipocancelacion)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOCANCELACION")
                    .HasMaxLength(2);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Saldo)
                    .HasColumnName("SALDO")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Secuencialcomponenteplazo).HasColumnName("SECUENCIALCOMPONENTEPLAZO");

                entity.Property(e => e.Secuencialdeposito).HasColumnName("SECUENCIALDEPOSITO");
            });

            modelBuilder.Entity<DepositocompPlazoRangotempz>(entity =>
            {
                entity.HasKey(e => e.Secuencialdepositocomplazo);

                entity.ToTable("DEPOSITOCOMP_PLAZO_RANGOTEMPZ", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencialdepositocomplazo)
                    .HasColumnName("SECUENCIALDEPOSITOCOMPLAZO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialrangotemporizacion).HasColumnName("SECUENCIALRANGOTEMPORIZACION");
            });

            modelBuilder.Entity<Rangotemporizacion>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("RANGOTEMPORIZACION", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Diasfinal).HasColumnName("DIASFINAL");

                entity.Property(e => e.Diasinicio).HasColumnName("DIASINICIO");

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialcuentacontable).HasColumnName("SECUENCIALCUENTACONTABLE");

                entity.Property(e => e.Secuencialempresa).HasColumnName("SECUENCIALEMPRESA");
            });

            modelBuilder.Entity<Depositobeneficiario>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("DEPOSITOBENEFICIARIO", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasColumnName("BENEFICIARIO")
                    .HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(200);

                entity.Property(e => e.Esconjunto).HasColumnName("ESCONJUNTO");

                entity.Property(e => e.Identificacionbeneficiario)
                    .HasColumnName("IDENTIFICACIONBENEFICIARIO")
                    .HasMaxLength(20);

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasColumnName("PARENTESCO")
                    .HasMaxLength(100);

                entity.Property(e => e.Secuencialdeposito).HasColumnName("SECUENCIALDEPOSITO");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<MovimientodepositocompPlazo>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("MOVIMIENTODEPOSITOCOMP_PLAZO", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigotipomovimiento)
                    .IsRequired()
                    .HasColumnName("CODIGOTIPOMOVIMIENTO")
                    .HasMaxLength(30);

                entity.Property(e => e.Saldo).HasColumnName("SALDO");

                entity.Property(e => e.Secuencialcomponenteplazo).HasColumnName("SECUENCIALCOMPONENTEPLAZO");

                entity.Property(e => e.Secuencialdeposito).HasColumnName("SECUENCIALDEPOSITO");

                entity.Property(e => e.Secuencialmovimientodetalle).HasColumnName("SECUENCIALMOVIMIENTODETALLE");

                entity.Property(e => e.Valor).HasColumnName("VALOR");
            });

            modelBuilder.Entity<Depositodocumentofisico>(entity =>
            {
                entity.HasKey(e => e.Secuencial);

                entity.ToTable("DEPOSITODOCUMENTOFISICO", "FBS_CAPTACIONESPLAZO");

                entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");

                entity.Property(e => e.Codigousuario)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20);

                entity.Property(e => e.Documentofisico)
                    .IsRequired()
                    .HasColumnName("DOCUMENTOFISICO")
                    .HasMaxLength(40);

                entity.Property(e => e.Estaactivo).HasColumnName("ESTAACTIVO");

                entity.Property(e => e.Fechamaquina)
                    .HasColumnName("FECHAMAQUINA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechasistema)
                    .HasColumnName("FECHASISTEMA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numeroverificador).HasColumnName("NUMEROVERIFICADOR");

                entity.Property(e => e.Secuencialdeposito).HasColumnName("SECUENCIALDEPOSITO");

            });
        }
    }
}