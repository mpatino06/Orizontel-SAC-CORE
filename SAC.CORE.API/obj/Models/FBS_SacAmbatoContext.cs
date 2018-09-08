using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        //public virtual DbSet<UsuarioComplemento1> UsuarioComplemento1 { get; set; }

        // Unable to generate entity type for table 'dbo.CALIFICACIONPRESTAMO'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-32QND9R;Initial Catalog=FBSSacAmbato;Integrated Security=True");            
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

                entity.HasOne(d => d.SecuencialpersonaNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.Secuencialpersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_R02");
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

                entity.HasOne(d => d.SecuencialpersonaNavigation)
                    .WithMany(p => p.Telefonopersona)
                    .HasForeignKey(d => d.Secuencialpersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TELEFONOPERSONA_R03");
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

                entity.HasOne(d => d.SecuencialpersonaNavigation)
                    .WithMany(p => p.UsuarioComplemento)
                    .HasForeignKey(d => d.Secuencialpersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_COMPLEMENTO_R01");
            });
          
        }
    }
}
