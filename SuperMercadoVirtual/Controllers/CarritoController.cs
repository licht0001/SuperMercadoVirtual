using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMercadoVirtual.Herramientas;
using SuperMercadoVirtual.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace SuperMercadoVirtual.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            var carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");  //para cada usuario en su sesion tendra un único carrito
            ViewBag.carrito = carrito;
            ViewBag.Total = carrito.Sum(elem => elem.Producto.Precio * elem.Cantidad);  //Usando LINQ
            return View();
        }
        [Route("Agregar/{id}")]
        public IActionResult Agregar(int id)
        {
            ProductoModel prodMod = new ProductoModel();
            if (ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito") == null)
            {
                List<Elemento> carrito = new List<Elemento>(); //si no uso se agrega
                carrito.Add(new Elemento { Producto = prodMod.getProducto(id), Cantidad = 1 });
                ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            else
            {
                List<Elemento> carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");
                int indice = existeProducto(id);
                if (indice > -1)
                {
                    carrito[indice].Cantidad++;
                }
                else
                {
                    carrito.Add(new Elemento { Producto = prodMod.getProducto(id), Cantidad = 1 });
                }
                ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");

        }
        private int existeProducto(int id)
        {
            List<Elemento> carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");
            for (int a = 0; a < carrito.Count; a++)
            {
                if (carrito[a].Producto.Id == (id))
                    return a;     // existio un producto y se retorna la posicion
            }
            return -1;   //no se encontro un producto con el id
        }
        [Route("Quitar/{id}")]
        public IActionResult Quitar(int id)
        {
            List<Elemento> carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");
            int indice = existeProducto(id);
            carrito.RemoveAt(indice);
            ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");

        }
        // prueba para poder eliminar un ELEMENTO de nuestro carrito
        [Route("Restar/{id}")]
        public IActionResult Restar(int id)
        {
            if (ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito") != null)
            {
                List<Elemento> carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");
                int indice = existeProducto(id);
                if (indice > -1)
                {
                    if (carrito[indice].Cantidad == 1)
                    {
                        //return RedirectToAction("Quitar");
                        carrito.RemoveAt(indice);
                        ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
                    }
                    else
                    {
                        carrito[indice].Cantidad--;
                        ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
                    }
                    ConversorParaSesion.ObjetoAJson(HttpContext.Session, "carrito", carrito);
                }
            }
            return RedirectToAction("Index");
        }
        //Se intentó...
        /*
        [Route("EliminarTodo/{id}")]
        public IActionResult EliminarTodo(int id)
        {

            List<Elemento> carrito = ConversorParaSesion.JsonAObjeto<List<Elemento>>(HttpContext.Session, "carrito");
            for (int a = 0; a < carrito.Count; a++)
            {
                carrito.RemoveAt(a);
            }
            return RedirectToAction("FinalizarCompras");
        */
        [HttpGet]
        //[Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("productos");
            return RedirectToAction("Index");
        }
    }
}
    

    

