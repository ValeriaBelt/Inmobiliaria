using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Apartamentos.Modelo
{
    public class Apto
    {
        [Key]
        [Column("idapartamento")]
        public int idapartamento { get; set; }
        [Required]
        public int piso { get; set; }
        [Required]
        public string amoblado { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public string longitud { get; set; }
       

    }
}
