using JuegoMarvelData.Models;
using Microsoft.EntityFrameworkCore;

namespace JuegoMarvelData.Data;

public partial class BbddjuegoMarvelContext : DbContext
{
    public BbddjuegoMarvelContext()
    {
    }

    public BbddjuegoMarvelContext(DbContextOptions<BbddjuegoMarvelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Habilidade> Habilidade { get; set; }

    public virtual DbSet<Pelea> Peleas { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<PersonajeUsuario> PersonajeUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo);

            entity.ToTable("Equipo");

            entity.HasOne(d => d.IdPersonajeUsuario1Navigation).WithMany(p => p.EquipoIdPersonajeUsuario1Navigations).HasForeignKey(d => d.IdPersonajeUsuario1).OnDelete(DeleteBehavior.Restrict).IsRequired(false);

            entity.HasOne(d => d.IdPersonajeUsuario2Navigation).WithMany(p => p.EquipoIdPersonajeUsuario2Navigations).HasForeignKey(d => d.IdPersonajeUsuario2).OnDelete(DeleteBehavior.Restrict).IsRequired(false);

            entity.HasOne(d => d.IdPersonajeUsuario3Navigation).WithMany(p => p.EquipoIdPersonajeUsuario3Navigations).HasForeignKey(d => d.IdPersonajeUsuario3).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        });

        modelBuilder.Entity<Habilidade>(entity =>
        {
            entity.HasKey(e => e.IdHabilidades);

            entity.HasOne(d => d.IdPersonajeNavigation).WithMany(p => p.Habilidades).HasForeignKey(d => d.IdPersonaje);
        });

        modelBuilder.Entity<Pelea>(entity =>
        {
            entity.HasKey(e => e.IdPeleas);
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.IdPersonaje);

            entity.ToTable("Personaje");
        });

        modelBuilder.Entity<PersonajeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdPersonajeUsuario);

            entity.ToTable("PersonajeUsuario");

            entity.Property(e => e.Nivel).HasDefaultValue(1);
            entity.Property(e => e.ValorHabilidad1).HasDefaultValue(0);
            entity.Property(e => e.ValorHabilidad2).HasDefaultValue(0);
            entity.Property(e => e.ValorHabilidad3).HasDefaultValue(0);

            entity.HasOne(d => d.IdPersonajeNavigation).WithMany(p => p.PersonajeUsuarios).HasForeignKey(d => d.IdPersonaje);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Experiencia).HasDefaultValue(0);
            entity.Property(e => e.Monedas).HasDefaultValue(0);
            entity.Property(e => e.SuperPuntos).HasDefaultValue(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
