using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Inquilino
    {
        [Key]
        [Column("iddocumento")]
        public int iddocumento { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public int idapartamento { get; set; }
        [Required]
        public Apto apartamentos { get; set; }
        

    }
}
