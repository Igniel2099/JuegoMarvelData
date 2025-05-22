using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class PersonajeUsuario
{
    public int IdPersonajeUsuario { get; set; }

    public int? IdPersonaje { get; set; }

    public int? Nivel { get; set; }

    public int? ValorHabilidad1 { get; set; }

    public int? ValorHabilidad2 { get; set; }

    public int? ValorHabilidad3 { get; set; }

    public int? IdEquipo { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Equipo> EquipoIdPersonajeUsuario1Navigations { get; set; } = new List<Equipo>();

    public virtual ICollection<Equipo> EquipoIdPersonajeUsuario2Navigations { get; set; } = new List<Equipo>();

    public virtual ICollection<Equipo> EquipoIdPersonajeUsuario3Navigations { get; set; } = new List<Equipo>();

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Personaje? IdPersonajeNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
