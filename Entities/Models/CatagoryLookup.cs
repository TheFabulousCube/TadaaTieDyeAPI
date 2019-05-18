using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("catagory_lookup")]
    public partial class CatagoryLookup
    {
        public CatagoryLookup()
        {
            Clothing = new HashSet<Clothing>();
        }

        [Key]
        [Column(TypeName = "varchar(10)")]
        public string CatId { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Type { get; set; }

        [InverseProperty("CatagoryNavigation")]
        public virtual ICollection<Clothing> Clothing { get; set; }
    }
}
