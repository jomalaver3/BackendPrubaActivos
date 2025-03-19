using Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace activosBackend.Models
{
    public class MovimientoInventarioModel
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public string ?TipoMovimiento { get; set; } // "Entrada" o "Salida"
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }  // Usuario que hizo el movimiento
    }
}
