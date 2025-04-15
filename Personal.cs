using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Personal
    {
        [Key]
        [Column("idpersonal")]
        public int idpersonal { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]        
        public string horario { get; set; }
        
    }
}
