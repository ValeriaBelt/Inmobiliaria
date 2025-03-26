namespace Apartamentos.Modelo
{
    public class Inquilino
    {
        public int documentoID { get; set; }
        public string nombre { get; set; }
        public int apartamentosID { get; set; }
        public string telefono { get; set; }
        public Apto apartamentos { get; set; }

    }
}
