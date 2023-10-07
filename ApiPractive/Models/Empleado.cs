using System;
using System.Collections.Generic;

namespace ApiPractive.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Puesto { get; set; } = null!;
}
