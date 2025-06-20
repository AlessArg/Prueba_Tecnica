using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public string? Nombre { get; set; }

    public int? CodigoCategoria { get; set; }

    public virtual Categorium? ObjetoCategorium { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
