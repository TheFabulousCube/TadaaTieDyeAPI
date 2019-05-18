using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("role_lookup")]
    public partial class RoleLookup
    {
        public RoleLookup()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        [Column(TypeName = "varchar(1)")]
        public string RoleId { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Role { get; set; }
        
        [InverseProperty("RoleNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
