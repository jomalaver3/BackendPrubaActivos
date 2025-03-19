using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovimientoInventario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required, MaxLength(10)]
        public string TipoMovimiento { get; set; } // "Entrada" o "Salida"

        [Required]
        public int Cantidad { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;

        [Required]
        public int UsuarioId { get; set; }  // Usuario que hizo el movimiento
    }
}
