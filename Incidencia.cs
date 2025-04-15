using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartamentos.Modelo
{
    public class Incidencia
    {
        [Key]
        [Column("idincidencia")]
        public int idincidencia { get; set; }
        [Required]
        public int idapartamento { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public Apto apartamentos { get; set; }
    }
}
