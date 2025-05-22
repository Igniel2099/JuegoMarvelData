using System;
using System.Collections.Generic;
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

    public virtual DbSet<Habilidade> Habilidades { get; set; }

    public virtual DbSet<Pelea> Peleas { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<PersonajeUsuario> PersonajeUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\walth\\Documents\\BBDDJuegoMarvel.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo);

            entity.ToTable("Equipo");

            entity.Property(e => e.IdEquipo).HasColumnName("Id_equipo");
            entity.Property(e => e.IdPersonajeUsuario1).HasColumnName("Id_personajeUsuario1");
            entity.Property(e => e.IdPersonajeUsuario2).HasColumnName("Id_personajeUsuario2");
            entity.Property(e => e.IdPersonajeUsuario3).HasColumnName("Id_personajeUsuario3");

            entity.HasOne(d => d.IdPersonajeUsuario1Navigation).WithMany(p => p.EquipoIdPersonajeUsuario1Navigations).HasForeignKey(d => d.IdPersonajeUsuario1);

            entity.HasOne(d => d.IdPersonajeUsuario2Navigation).WithMany(p => p.EquipoIdPersonajeUsuario2Navigations).HasForeignKey(d => d.IdPersonajeUsuario2);

            entity.HasOne(d => d.IdPersonajeUsuario3Navigation).WithMany(p => p.EquipoIdPersonajeUsuario3Navigations).HasForeignKey(d => d.IdPersonajeUsuario3);
        });

        modelBuilder.Entity<Habilidade>(entity =>
        {
            entity.HasKey(e => e.IdHabilidades);

            entity.Property(e => e.IdHabilidades).HasColumnName("Id_habilidades");
            entity.Property(e => e.IdPersonaje).HasColumnName("Id_personaje");

            entity.HasOne(d => d.IdPersonajeNavigation).WithMany(p => p.Habilidades).HasForeignKey(d => d.IdPersonaje);
        });

        modelBuilder.Entity<Pelea>(entity =>
        {
            entity.HasKey(e => e.IdPeleas);

            entity.Property(e => e.IdPeleas).HasColumnName("Id_peleas");

            entity.HasOne(d => d.GanadorNavigation).WithMany(p => p.PeleaGanadorNavigations).HasForeignKey(d => d.Ganador);

            entity.HasOne(d => d.PrimerUsuarioNavigation).WithMany(p => p.PeleaPrimerUsuarioNavigations).HasForeignKey(d => d.PrimerUsuario);

            entity.HasOne(d => d.SegundoUsuarioNavigation).WithMany(p => p.PeleaSegundoUsuarioNavigations).HasForeignKey(d => d.SegundoUsuario);
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.IdPersonaje);

            entity.ToTable("Personaje");

            entity.Property(e => e.IdPersonaje).HasColumnName("Id_personaje");
        });

        modelBuilder.Entity<PersonajeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdPersonajeUsuario);

            entity.ToTable("PersonajeUsuario");

            entity.Property(e => e.IdPersonajeUsuario).HasColumnName("Id_personajeUsuario");
            entity.Property(e => e.IdEquipo).HasColumnName("Id_equipo");
            entity.Property(e => e.IdPersonaje).HasColumnName("Id_personaje");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Nivel).HasDefaultValue(1);
            entity.Property(e => e.ValorHabilidad1)
                .HasDefaultValue(0)
                .HasColumnName("Valor_Habilidad1");
            entity.Property(e => e.ValorHabilidad2)
                .HasDefaultValue(0)
                .HasColumnName("Valor_Habilidad2");
            entity.Property(e => e.ValorHabilidad3)
                .HasDefaultValue(0)
                .HasColumnName("Valor_Habilidad3");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.PersonajeUsuarios).HasForeignKey(d => d.IdEquipo);

            entity.HasOne(d => d.IdPersonajeNavigation).WithMany(p => p.PersonajeUsuarios).HasForeignKey(d => d.IdPersonaje);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PersonajeUsuarios).HasForeignKey(d => d.IdUsuario);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdEquipo, "IX_Usuario_Id_equipo").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Experiencia).HasDefaultValue(0);
            entity.Property(e => e.IdEquipo).HasColumnName("Id_equipo");
            entity.Property(e => e.Monedas).HasDefaultValue(0);
            entity.Property(e => e.SuperPuntos).HasDefaultValue(0);

            entity.HasOne(d => d.IdEquipoNavigation).WithOne(p => p.Usuario).HasForeignKey<Usuario>(d => d.IdEquipo);

            entity.HasMany(d => d.IdPeleas).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "PeleasUsuario",
                    r => r.HasOne<Pelea>().WithMany()
                        .HasForeignKey("IdPeleas")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdPeleas");
                        j.ToTable("PeleasUsuario");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("Id_usuario");
                        j.IndexerProperty<int>("IdPeleas").HasColumnName("Id_peleas");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
