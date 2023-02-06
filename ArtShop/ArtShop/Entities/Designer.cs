using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Entities
{
    public class Designer
    {
        public int Id { get; set; }

        [Required]
        public string DesignerName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
