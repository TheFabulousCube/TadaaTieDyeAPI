using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("size_lookup")]
    public partial class SizeLookup
    {
        public SizeLookup()
        {
            Clothing = new HashSet<Clothing>();
        }

        [Key]
        [Column(TypeName = "varchar(6)")]
        public string SizeId { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Size { get; set; }

        [InverseProperty("SizeNavigation")]
        public virtual ICollection<Clothing> Clothing { get; set; }
    }
}
