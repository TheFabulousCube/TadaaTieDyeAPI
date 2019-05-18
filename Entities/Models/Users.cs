using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("users")]
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Fname { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Lname { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string State { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Zip { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Role { get; set; }

        [ForeignKey("Role")]
        [InverseProperty("Users")]
        public virtual RoleLookup RoleNavigation { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
