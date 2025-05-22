using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Pelea
{
    public int IdPeleas { get; set; }

    public int? PrimerUsuario { get; set; }

    public int? SegundoUsuario { get; set; }

    public int? Ganador { get; set; }

    public virtual Usuario? GanadorNavigation { get; set; }

    public virtual Usuario? PrimerUsuarioNavigation { get; set; }

    public virtual Usuario? SegundoUsuarioNavigation { get; set; }

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
