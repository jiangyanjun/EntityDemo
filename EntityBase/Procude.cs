using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityBase
{
    [Table("Table_Procude")]
   public class Procude
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(4),MinLength(1)]
        public string Name { get; set; }
        [Required]
        public bool Sex { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
