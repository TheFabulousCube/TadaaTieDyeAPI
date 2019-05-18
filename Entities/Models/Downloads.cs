using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("downloads")]
    public partial class Downloads
    {
        [Key]
        [Column("FileNameID", TypeName = "varchar(25)", Order = 1)]
        public string FileNameId { get; set; }

        [Column("Downloads", TypeName = "int(11)")]
        public int? Downloads1 { get; set; }

        [Key]
        [Column(TypeName = "varchar(45)", Order = 2)]
        public string Date { get; set; }
    }
}
