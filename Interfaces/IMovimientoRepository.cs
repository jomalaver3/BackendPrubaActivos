using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IMovimientoRepository
    {
        Task<List<Producto>> ObtenerProductosAsync();
        Task<Producto> ObtenerProductoPorIdAsync(int id);
        Task AgregarProductoAsync(Producto producto);
        Task AgregarMovimientoInventarioAsync(MovimientoInventario movimiento);



    }
}
