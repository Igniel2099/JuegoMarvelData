using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Personaje
{
    public int IdPersonaje { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Grupo { get; set; }

    public int? Coste { get; set; }

    public virtual ICollection<Habilidade> Habilidades { get; set; } = new List<Habilidade>();

    public virtual ICollection<PersonajeUsuario> PersonajeUsuarios { get; set; } = new List<PersonajeUsuario>();
}
