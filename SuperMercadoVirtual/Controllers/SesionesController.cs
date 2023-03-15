using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMercadoVirtual.Herramientas;
using SuperMercadoVirtual.Models;
using System.Collections.Generic;

namespace SuperMercadoVirtual.Controllers
{
    public class SesionesController : Controller
    {
        public IActionResult Index()
        {
            //Valores para la sesión:
            HttpContext.Session.SetInt32("edad", 37);   //llave, valor
            HttpContext.Session.SetString("usuario", "Lichtgestalt"); //llave, valor

            //Objeto Producto para la sesión:
            Producto producto = new Producto
            {
                Id = 01,
                Nombre = "Docking_Station",
                Precio = 788.10,
                Imagen = "Docking_Station.jpg",
            };

            ConversorParaSesion.ObjetoAJson(HttpContext.Session, "producto", producto);  // una llave y su valor - objeto a string y ese a una sesion y 

            //Pasando una lista de productos
            List<Producto> productos = new List<Producto>() {
                new Producto {
                Id = 1,
                Nombre = "Docking_Station",
                Precio = 788.10,
                Imagen = "Docking_Station.jpg",
                },
                new Producto {
                Id = 2,
                Nombre = "Imac27",
                Precio = 8500,
                Imagen = "Imac27.jpg",
                },
                new Producto {
                Id = 3,
                Nombre = "Lector_M2_USB3",
                Precio = 545,
                Imagen = "Lector_M2_USB3.jpg",
                },
                new Producto {
                Id = 4,
                Nombre = "Parlantes_Creative",
                Precio = 1200,
                Imagen = "Parlantes_Creative.jpg",
                },
                new Producto {
                Id = 5,
                Nombre = "Portable",
                Precio = 545,
                Imagen = "Portable.jpg",
                },
                new Producto {
                Id = 6,
                Nombre = "Teclado_Apple",
                Precio = 1600,
                Imagen = "Teclado_Apple.jpg",
                },
                new Producto {
                Id = 7,
                Nombre = "Teclado_Mecanico",
                Precio = 470,
                Imagen = "Teclado_Mecanico.jpg",
                }
            };
            ConversorParaSesion.ObjetoAJson(HttpContext.Session, "productos", productos);

            return View("Index");
        }
    }
}