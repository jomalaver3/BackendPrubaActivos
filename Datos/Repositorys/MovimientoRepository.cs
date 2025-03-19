using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Context;
using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositorys
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly contextDb _context;

        public MovimientoRepository(contextDb context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task AgregarProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarMovimientoInventarioAsync(MovimientoInventario movimiento)
        {
            _context.MovimientosInventario.Add(movimiento);
            await _context.SaveChangesAsync();
        }
    }
}
