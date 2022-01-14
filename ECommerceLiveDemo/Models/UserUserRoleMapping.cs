using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class UserUserRoleMapping
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? UserRoleId { get; set; }

        public virtual User User { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
