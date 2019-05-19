using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("cart")]
    public partial class Cart
    {
        [Key]
        [Column(TypeName = "int(11)")]
        [Required(ErrorMessage ="UserId is required")]
        public int UserId { get; set; }

        [Column("ProdID", TypeName = "varchar(4)")]
        public string ProdId { get; set; }

        [Column(TypeName = "int(11)")]
        public int Qty { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Cart")]
        public virtual Users User { get; set; }
    }
}
