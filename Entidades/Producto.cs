using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public int Stock { get; set; } = 0;

        [Required]
        public decimal Precio { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
