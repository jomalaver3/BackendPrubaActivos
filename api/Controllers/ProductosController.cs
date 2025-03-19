using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using activosBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Datos.Repositorys;
using Entidades;
using Microsoft.AspNetCore.Authorization;

namespace activosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetProductos()
        {
            return Ok(await _productoService.GetProductos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoModel>> GetProducto(int id)
        {

            var producto = await _productoService.GetProductoById(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        [HttpPost("agregar")]

        public async Task<ActionResult> PostProducto(ProductoModel producto)
        {

            var produc = MapProducto(producto);
            await _productoService.AddProducto(produc);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("actualizar")]

        public async Task<IActionResult> PutProducto( ProductoModel producto)
        {
            //if (id != producto.Id)
            //    return BadRequest();

            var product = MapProducto(producto);
            await _productoService.UpdateProducto(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoService.DeleteProducto(id);
            return NoContent();
        }

        private Producto MapProducto(ProductoModel model)
        {
            return new Producto
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Stock = model.Stock,
                Precio = model.Precio,
                Categoria = model.Categoria,
                FechaRegistro = model.FechaRegistro

            };
        }

    }
}