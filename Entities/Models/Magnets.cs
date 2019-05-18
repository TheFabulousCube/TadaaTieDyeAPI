using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("magnets")]
    public partial class Magnets
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string ProdId { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string ProdPicture { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal ProdPrice { get; set; }

        [Column(TypeName = "int(11)")]
        public int ProdQty { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Catagory { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string ProdName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Capital { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Statehood { get; set; }
    }
}
