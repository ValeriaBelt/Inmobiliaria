using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Mantenimiento
    {
        [Key]
        [Column("idmantenimiento")]
        public int idmantenimiento { get; set; }
        [Required]
        public int idapartamento { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public decimal costo { get; set; }
        [Required]
        public int idpersonal { get; set; }
        [Required]
        public Apto apartamentos { get; set; }
        [Required]
        public Personal personal { get; set; }
    }
}
