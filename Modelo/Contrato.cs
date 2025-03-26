namespace Apartamentos.Modelo
{
    public class Contrato
    {
        public int contratoID { get; set; }
        public int apartamentosID { get; set; }
        public int documentoID { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public string estado { get; set; }
        public string servicios { get; set; }
        public Apto apartamentos { get; set; }
        public Inquilino inquilino { get; set; }

    }
}
