using System.ComponentModel.DataAnnotations;

namespace activosBackend.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; } = 0;

        public decimal Precio { get; set; }

        public string Categoria { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
