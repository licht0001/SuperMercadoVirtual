using Microsoft.AspNetCore.Mvc;
using SuperMercadoVirtual.Herramientas;
using SuperMercadoVirtual.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperMercadoVirtual.Controllers
{
    public class FinalizarCompraController : Controller
    {
        public IActionResult Index()
        {
            var carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");  //para cada usuario en su sesion tendra un único carrito
            ViewBag.carrito = carrito;
            ViewBag.Total = carrito.Sum(elem => elem.Producto.Precio * elem.Cantidad);  //Usando LINQ
            return View();
        }
    }
}
