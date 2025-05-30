using System;
using System.Collections.Generic;

namespace JuegoMarvelData.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int? Experiencia { get; set; }

    public int? Monedas { get; set; }

    public int? SuperPuntos { get; set; }
}
