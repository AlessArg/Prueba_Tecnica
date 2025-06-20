using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Categorium
{
    public int CodigoCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
