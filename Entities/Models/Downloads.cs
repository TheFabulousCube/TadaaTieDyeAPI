using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("downloads")]
    public partial class Downloads
    {
        [Column("FileNameID", TypeName = "varchar(25)")]
        public string FileNameId { get; set; }

        [Column("Downloads", TypeName = "int(11)")]
        public int? Downloads1 { get; set; }

        [Key]
        [Column(TypeName = "varchar(45)")]
        public string Date { get; set; }
    }
}
