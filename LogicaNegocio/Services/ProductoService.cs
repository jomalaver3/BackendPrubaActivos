using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;

namespace LogicaNegocio.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _productoRepository.GetProductos();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _productoRepository.GetProductoById(id);
        }

        public async Task AddProducto(Producto producto)
        {
            await _productoRepository.AddProducto(producto);
        }

        public async Task UpdateProducto(Producto producto)
        {
            await _productoRepository.UpdateProducto(producto);
        }

        public async Task DeleteProducto(int id)
        {
            await _productoRepository.DeleteProducto(id);
        }

    }
}
