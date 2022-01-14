using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class ProductVideoMapping
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? VideoId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Video Video { get; set; }
    }
}
