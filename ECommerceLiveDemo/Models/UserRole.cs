using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserUserRoleMappings = new HashSet<UserUserRoleMapping>();
        }

        public int Id { get; set; }
        [DisplayName("Rol İsmi")]
        public string Name { get; set; }
        [DisplayName("Rol Sistem İsmi")]
        public string SystemName { get; set; }

        public virtual ICollection<UserUserRoleMapping> UserUserRoleMappings { get; set; }
    }
}
