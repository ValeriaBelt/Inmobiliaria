using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Pago
    {
        [Key]
        [Column("idpago")]
        public int idpago { get; set; }
        [Required]
        public int idcontrato { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public decimal costo { get; set; }
        [Required]
        public Contrato contrato { get; set; }

    }
}
