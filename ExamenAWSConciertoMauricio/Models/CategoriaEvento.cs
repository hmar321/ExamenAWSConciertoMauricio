using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenAWSConciertoMauricio.Models
{
    [Table("categoriaevento")]
    public class CategoriaEvento
    {
        [Key]
        [Column("idcategoria")]
        public int IdCategoria { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
