namespace Apartamentos.Modelo
{
    public class Pago
    {
        public int pagosID { get; set; }
        public int contratoID { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public Contrato contrato { get; set; }

    }
}
