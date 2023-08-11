using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineMarket.Models.Enums.ProjectEnums;

namespace OnlineMarket.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public UserType RoleName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
