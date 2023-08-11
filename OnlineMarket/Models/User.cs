using System.ComponentModel.DataAnnotations;
using static OnlineMarket.Models.Enums.ProjectEnums;

namespace OnlineMarket.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(4)]
        public string PostCode { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role{ get; set;}

    }
}
