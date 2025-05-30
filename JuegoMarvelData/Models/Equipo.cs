using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public int? IdPersonajeUsuario1 { get; set; }

    public int? IdPersonajeUsuario2 { get; set; }

    public int? IdPersonajeUsuario3 { get; set; }

    public virtual PersonajeUsuario? IdPersonajeUsuario1Navigation { get; set; }

    public virtual PersonajeUsuario? IdPersonajeUsuario2Navigation { get; set; }

    public virtual PersonajeUsuario? IdPersonajeUsuario3Navigation { get; set; }
}
