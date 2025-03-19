using activosBackend.Models;
using Interfaces;
using LogicaNegocio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace activosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _service;

        public MovimientoController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet("productos")]
        public async Task<ActionResult<List<ProductoModel>>> ObtenerProductos()
        {
            return Ok( await _service.ObtenerProductosAsync());
        }

        [HttpPost("movimiento")]
        public async Task<IActionResult> RegistrarEntradaSalida([FromBody] MovimientoInventarioModel movimiento)
        {
            await _service.RegistrarEntradaSalidaAsync(movimiento.ProductoId, movimiento.Cantidad, movimiento.TipoMovimiento, movimiento.UsuarioId);
            return Ok(new { mensaje = "Movimiento registrado correctamente" });
        }
    }
}
