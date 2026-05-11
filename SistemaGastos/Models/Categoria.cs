namespace SistemaGastos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;

        // Una categoria puede tener muchos gastos
        public List<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
