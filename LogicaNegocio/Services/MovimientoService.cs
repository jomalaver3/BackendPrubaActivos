using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;

namespace LogicaNegocio.Services
{
    public class MovimientoService : IMovimientoService
    {

      private readonly IMovimientoRepository _repository;

        public MovimientoService(IMovimientoRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _repository.ObtenerProductosAsync();
        }

        public async Task RegistrarEntradaSalidaAsync(int productoId, int cantidad, string tipo, int usuarioId)
        {
            var producto = await _repository.ObtenerProductoPorIdAsync(productoId);
            if (producto == null) throw new System.Exception("Producto no encontrado");

            if (tipo == "Salida" && producto.Stock < cantidad)
                throw new System.Exception("Stock insuficiente");

            producto.Stock += (tipo == "Entrada" ? cantidad : -cantidad);

            await _repository.AgregarMovimientoInventarioAsync(new MovimientoInventario
            {
                ProductoId = productoId,
                TipoMovimiento = tipo,
                Cantidad = cantidad,
                UsuarioId = usuarioId
            });
        }
    }

}
