using System;
using System.Collections.Generic;

namespace CRUD.Models
{
public partial class Juego
{
    public int IdVideojuego { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Anio { get; set; }

    public int Calificacion { get; set; }

    public string Genero { get; set; } = null!;

    public int ConsolaId { get; set; }
}
}

