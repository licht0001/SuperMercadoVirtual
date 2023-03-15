using System.Collections.Generic;
using System.Linq;

namespace SuperMercadoVirtual.Models
{
    public class ProductoModel
    {
        private List<Producto> productos;
        public ProductoModel()
        {
            productos = new List<Producto>() {
               new Producto {
                Id = 1,
                Nombre = "Docking_Station",
                Precio = 788.1,
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
        }
        //Utilizando a LINQ
        public List<Producto> getTodo()
        {
            return productos;                                   //retornar un conjunto de objetos
        }
        public Producto getProducto(int id)
        {
            return productos.Single(p => p.Id.Equals(id));      //retornar un Solo Producto
        }
    }
}
