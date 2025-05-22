using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? Experiencia { get; set; }

    public int? Monedas { get; set; }

    public int? SuperPuntos { get; set; }

    public int? IdEquipo { get; set; }

    public int? CodigoConfirmacion { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual ICollection<Pelea> PeleaGanadorNavigations { get; set; } = new List<Pelea>();

    public virtual ICollection<Pelea> PeleaPrimerUsuarioNavigations { get; set; } = new List<Pelea>();

    public virtual ICollection<Pelea> PeleaSegundoUsuarioNavigations { get; set; } = new List<Pelea>();

    public virtual ICollection<PersonajeUsuario> PersonajeUsuarios { get; set; } = new List<PersonajeUsuario>();

    public virtual ICollection<Pelea> IdPeleas { get; set; } = new List<Pelea>();
}
