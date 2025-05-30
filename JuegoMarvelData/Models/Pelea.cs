using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Pelea
{
    public int IdPeleas { get; set; }

    public string ContrincanteUsuario { get; set; } = null!;

    public int? SoyGanador { get; set; }
}
