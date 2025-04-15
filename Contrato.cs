using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Contrato
    {
        internal object apartamento;

        [Key]
        [Column("idcontrato")]
        public int idcontrato { get; set; }
        [Required]
        public int idapartamento { get; set; }
        [Required]
        public int iddocumento { get; set; }
        [Required]
        public DateTime fechaInicio { get; set; }
        [Required]
        public DateTime fechaFin { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public string servicios { get; set; }
        [Required]
        public Apto Apto { get; set; }
        public Inquilino inquilino { get; set; }
    }
}
