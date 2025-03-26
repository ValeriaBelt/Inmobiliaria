namespace Apartamentos.Modelo
{
    public class Mantenimiento
    {
        public int mantenimientoID { get; set; }
        public int apartamentosID { get; set; }
        public string tipo { get; set; }
        public DateTime fecha { get; set; }
        public decimal costo { get; set; }
        public int personalID { get; set; }
        public Apto apartamentos { get; set; }
        public Personal personal { get; set; }
    }
}
