using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Context;
using Interfaces;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositorys
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly contextDb _context;

        public ProductoRepository(contextDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task AddProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
