using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prueba_Tecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly Prueba_Tecnica_GuatemalaDigitalContext DBContext;

        public HomeController(Prueba_Tecnica_GuatemalaDigitalContext context)
        {
            DBContext = context;
        }

        public IActionResult Index(int? categoriaID, int? a�o)
        {
            var categorias = DBContext.Venta
                .Where(v => v.Fecha.HasValue)
                .Where(v => v.ObjetoProducto != null && v.ObjetoProducto.ObjetoCategorium != null)
                .Select(v => new {
                    CodigoCategoria = v.ObjetoProducto.ObjetoCategorium.CodigoCategoria,
                    Nombre = v.ObjetoProducto.ObjetoCategorium.Nombre
                })
                .Distinct()
                .ToList();

            ViewBag.Categorias = new SelectList(categorias, "CodigoCategoria", "Nombre", categoriaID);
            ViewBag.CategoriaSeleccionada = categoriaID;

            var a�os = DBContext.Venta
                .Where(v => v.Fecha.HasValue)
                .Select(v => v.Fecha.Value.Year)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();

            ViewBag.A�os = new SelectList(a�os.Select(a => new { Value = a, Text = a }), "Value", "Text", a�o);
            ViewBag.A�oSeleccionado = a�o;

            List<Ventum> ventas = new();

            if (categoriaID.HasValue)
            {
                var ventasQuery = DBContext.Venta
                    .Include(v => v.ObjetoProducto)
                    .ThenInclude(p => p.ObjetoCategorium)
                    .Where(v => v.Fecha.HasValue)
                    .Where(v => v.ObjetoProducto.CodigoCategoria == categoriaID.Value);

                if (a�o.HasValue)
                {
                    ventasQuery = ventasQuery.Where(v => v.Fecha.Value.Year == a�o.Value);
                }

                ventas = ventasQuery.ToList();
            }

            return View(ventas);
        }
    }
}
