using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Habilidade
{
    public int IdHabilidades { get; set; }

    public int? IdPersonaje { get; set; }

    public string? Nombre { get; set; }

    public int? Valor { get; set; }

    public string? Tipo { get; set; }

    public virtual Personaje? IdPersonajeNavigation { get; set; }
}
