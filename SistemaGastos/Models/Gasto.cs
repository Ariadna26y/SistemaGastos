namespace SistemaGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty; // "Gasto" o "Ingreso"
        public int CategoriaId { get; set; }

        // Relación con Categoria
        public Categoria? Categoria { get; set; }
    }
}
