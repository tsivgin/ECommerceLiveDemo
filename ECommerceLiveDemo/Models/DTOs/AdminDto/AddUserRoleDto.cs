using System.Collections.Generic;
using System.ComponentModel;

namespace ECommerceLiveDemo.Models.DTOs.AdminDto
{
    public class AddUserRoleDto
    {
        
        public int Id { get; set; }
        [DisplayName("Email")]
        public string? Email { get; set; }
        [DisplayName("User role")]
        public List<UserRole> UserRoles { get; set; }
        [DisplayName("UserRolesMapping")]
        public virtual ICollection<UserUserRoleMapping>? UserUserRoleMappings { get; set; }
        
    }

}