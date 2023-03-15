using Microsoft.AspNetCore.Mvc;
using SuperMercadoVirtual.Models;

namespace SuperMercadoVirtual.Controllers
{
    public class ProductoParaCarritoController : Controller
    {
        public IActionResult Index()
        {
            var prodModel = new ProductoModel();
            ViewBag.productos = prodModel.getTodo();
            return View();
        }
    }
}
