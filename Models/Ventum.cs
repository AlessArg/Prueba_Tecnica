using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Ventum
{
    public int CodigoVenta { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? CodigoProducto { get; set; }

    public virtual Producto? ObjetoProducto { get; set; }
}
