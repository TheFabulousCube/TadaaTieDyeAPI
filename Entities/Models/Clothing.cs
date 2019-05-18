using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("clothing")]
    public partial class Clothing
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
        [Column(TypeName = "varchar(25)")]
        public string BackPicture { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string Size { get; set; }

        [Required]
        [Column(TypeName = "varchar(2)")]
        public string SleeveLength { get; set; }

        [ForeignKey("Catagory")]
        [InverseProperty("Clothing")]
        public virtual CatagoryLookup CatagoryNavigation { get; set; }

        [ForeignKey("Size")]
        [InverseProperty("Clothing")]
        public virtual SizeLookup SizeNavigation { get; set; }

        [ForeignKey("SleeveLength")]
        [InverseProperty("Clothing")]
        public virtual SleeveLookup SleeveLengthNavigation { get; set; }
    }
}
