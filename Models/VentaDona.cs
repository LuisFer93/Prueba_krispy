using System.ComponentModel.DataAnnotations;

namespace Prueba_donas.Models
{
    public class VentaDona
    {
        public int Id { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required]
        public required string Direccion { get; set; }

        [Required]
        public required string TipoDona { get; set; }

        [Required]
        public required int Cantidad { get; set; }
    }
}
