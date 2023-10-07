using System;
using System.Collections.Generic;

namespace ApiPractive.Models;

public partial class Doctore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int IdEmpleado { get; set; }
}
