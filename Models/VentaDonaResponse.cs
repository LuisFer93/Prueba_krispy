namespace Prueba_donas.Models
{
    public class VentaDonaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TipoDona { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
    }
}
