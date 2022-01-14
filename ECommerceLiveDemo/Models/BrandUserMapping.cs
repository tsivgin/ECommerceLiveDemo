using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class BrandUserMapping
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
