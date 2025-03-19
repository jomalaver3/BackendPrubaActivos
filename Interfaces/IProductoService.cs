using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task AddProducto(Producto producto);
        Task UpdateProducto(Producto producto);
        Task DeleteProducto(int id);
    }
}
