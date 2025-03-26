namespace Apartamentos.Modelo
{
    public class Incidencia
    {
        public int incidenciasID { get; set; }
        public int apartamentosID { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public Apto apartamentos { get; set; }

    }
}
