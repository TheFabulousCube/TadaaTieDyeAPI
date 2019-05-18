using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("sleeve_lookup")]
    public partial class SleeveLookup
    {
        public SleeveLookup()
        {
            Clothing = new HashSet<Clothing>();
        }

        [Key]
        [Column("SleeveID", TypeName = "varchar(2)")]
        public string SleeveId { get; set; }

        [Required]
        [Column("Sleeve Length", TypeName = "varchar(12)")]
        public string SleeveLength { get; set; }

        [InverseProperty("SleeveLengthNavigation")]
        public virtual ICollection<Clothing> Clothing { get; set; }
    }
}
