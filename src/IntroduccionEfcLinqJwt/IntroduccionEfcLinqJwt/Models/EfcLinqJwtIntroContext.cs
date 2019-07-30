using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class EfcLinqJwtIntroContext : DbContext
    {
        public EfcLinqJwtIntroContext()
        {
        }

        public EfcLinqJwtIntroContext(DbContextOptions<EfcLinqJwtIntroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoPersona> CursoPersona { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Server=.;Database=EfcLinqJwtIntro;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("curso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cupos).HasColumnName("cupos");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.Dias)
                    .HasColumnName("dias")
                    .HasMaxLength(50);

                entity.Property(e => e.Turno).HasColumnName("turno");

                entity.HasOne(d => d.TurnoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.Turno)
                    .HasConstraintName("FK__curso__turno__3E52440B");
            });

            modelBuilder.Entity<CursoPersona>(entity =>
            {
                entity.ToTable("curso_persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoPersona)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__curso_per__id_cu__412EB0B6");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.CursoPersona)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__curso_per__id_pe__4222D4EF");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(50);

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(50);

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK__persona__rol__3B75D760");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("turno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);
            });
        }
    }
}
