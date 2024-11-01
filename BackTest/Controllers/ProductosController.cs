using Microsoft.AspNetCore.Mvc;
using BackTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto 1", Precio = 10.00M },
            new Producto { Id = 2, Nombre = "Producto 2", Precio = 20.00M }
        };

        // GET: api/productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return productos;
        }

        // GET: api/productos/1
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return producto;
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Count + 1;
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        // PUT: api/productos/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            return NoContent();
        }

        // DELETE: api/productos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();

            productos.Remove(producto);
            return NoContent();
        }
    }
}
